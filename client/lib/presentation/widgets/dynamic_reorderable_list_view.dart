// Flutter imports:
import 'package:flutter/material.dart';

class DynamicReorderableListView<T> extends StatefulWidget {
  final Widget? title;
  final Widget Function(BuildContext context, int index) itemBuilder;
  final Iterable<T> items;
  final T initialValue;
  final void Function(Iterable<T> items)? onChanged;
  final void Function(T added, int index)? onAdded;
  final void Function(T deleted, int index)? onDeleted;
  final void Function(int oldIndex, int newIndex)? onReordered;

  const DynamicReorderableListView({
    this.title,
    required this.items,
    required this.itemBuilder,
    required this.initialValue,
    this.onChanged,
    this.onReordered,
    this.onAdded,
    this.onDeleted,
  });

  @override
  State<StatefulWidget> createState() =>
      _DynamicReorderableListViewState<T>(items);
}

final class _DynamicReorderableListViewState<T>
    extends State<DynamicReorderableListView<T>> {
  late final List<T> _items;

  _DynamicReorderableListViewState(Iterable<T> items) {
    _items = List.from(items);
  }

  @override
  Widget build(BuildContext context) {
    return ExpansionTile(
      title: widget.title ?? SizedBox.shrink(),
      initiallyExpanded: true,
      leading: IconButton(
        onPressed: onAdd,
        icon: Icon(Icons.add),
      ),
      children: [
        ReorderableListView.builder(
          itemBuilder: (context, index) {
            final item = widget.itemBuilder(context, index);
            return Row(
              key: ValueKey(index),
              children: [
                ReorderableDragStartListener(
                  index: index,
                  child: Icon(Icons.drag_handle),
                ),
                Expanded(
                  child: item,
                ),
                IconButton(
                  onPressed: () => onDelete(index),
                  icon: Icon(Icons.delete),
                ),
              ],
            );
          },
          buildDefaultDragHandles: false,
          itemCount: _items.length,
          physics: NeverScrollableScrollPhysics(),
          shrinkWrap: true,
          onReorder: onReorder,
        ),
      ],
    );
  }

  void onReorder(int oldIndex, int newIndex) {
    setState(() {
      if (newIndex > oldIndex) {
        newIndex -= 1;
      }
      final item = _items.removeAt(oldIndex);
      _items.insert(newIndex, item);
    });
    widget.onReordered?.call(oldIndex, newIndex);
    widget.onChanged?.call(_items);
  }

  void onAdd() {
    setState(() {
      _items.add(widget.initialValue);
    });
    widget.onAdded?.call(widget.initialValue, _items.length - 1);
    widget.onChanged?.call(_items);
  }

  void onDelete(int index) {
    late final T deleted;
    setState(() {
      deleted = _items.removeAt(index);
    });
    widget.onDeleted?.call(deleted, index);
    widget.onChanged?.call(_items);
  }
}

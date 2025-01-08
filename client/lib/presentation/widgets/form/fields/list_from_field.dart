// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';

// Project imports:
import 'package:bot_runner/presentation/widgets/dynamic_reorderable_list_view.dart';

class ListFromField<T> extends FormBuilderField<List<T>> {
  ListFromField({
    required super.name,
    required T addedItialValue,
    required Widget Function(
            BuildContext context, int index, FormFieldState<List<T>> field)
        itemBuilder,
    super.initialValue,
    super.valueTransformer,
    Iterable<T> Function(T element, int index)? onAdded,
    Iterable<T> Function(T element, int index)? onDeleted,
    Iterable<T> Function(int oldIndex, int newIndex)? onReordered,
  }) : super(
          builder: (field) {
            final items = field.value ?? [];
            return DynamicReorderableListView<T>(
              title: Text(name),
              items: items,
              itemBuilder: (context, index) {
                return itemBuilder(context, index, field);
              },
              initialValue: addedItialValue,
              onAdded: (element, index) {
                final res = onAdded?.call(element, index);
                if (res != null) {
                  field.didChange(res.toList());
                }
              },
              onDeleted: (element, index) {
                final res = onDeleted?.call(element, index);
                if (res != null) {
                  field.didChange(res.toList());
                }
              },
              onReordered: (oldIndex, newIndex) {
                final res = onReordered?.call(oldIndex, newIndex);
                if (res != null) {
                  field.didChange(res.toList());
                }
              },
            );
          },
        );
}

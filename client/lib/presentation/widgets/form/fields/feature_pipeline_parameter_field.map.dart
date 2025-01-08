part of 'feature_pipeline_parameter_field.dart';

final class FeaturePipelineMapParameterField extends StatefulWidget {
  final String name;
  final FeaturePipelineParameterOrder order;

  FeaturePipelineMapParameterField({
    required this.name,
    required this.order,
  });

  @override
  State<StatefulWidget> createState() => _FeaturePipelineMapParameterField();
}

final class _FeaturePipelineMapParameterField
    extends State<FeaturePipelineMapParameterField> {
  late final List<MapEntry<String, String>> _entries;
  late final MapEntry<String, String> _defaultValue;

  @override
  void initState() {
    super.initState();
    final key = widget.order.value.mapValue.selectableKeys.options.isNotEmpty
        ? widget.order.value.mapValue.selectableKeys.options.first
        : "";
    final value = widget.order.value.mapValue.selectableValues.options.isNotEmpty
        ? widget.order.value.mapValue.selectableValues.options.first
        : "";
    _entries = widget.order.value.mapValue.values.entries.toList();
    _defaultValue = MapEntry(key, value);
  }

  @override
  Widget build(BuildContext context) {
    return ListFromField<MapEntry<String, String>>(
      name: widget.name,
      addedItialValue: _defaultValue,
      initialValue: _entries,
      itemBuilder: (context, index, field) {
        final pair = _entries.elementAt(index);
        return KeyValueField(
          initialValue: pair,
          selectableKeys: widget.order.value.mapValue.selectableKeys.options,
          selectableValues:
              widget.order.value.mapValue.selectableValues.options,
          onChanged: (value) {
            setState(() {
              _entries[index] = value;
            });
            field.didChange(_entries);
          },
        );
      },
      onAdded: onAdded,
      onDeleted: onDeleted,
      onReordered: onReordered,
      valueTransformer: valueTransform,
    );
  }

  Iterable<MapEntry<String, String>> onAdded(
      MapEntry<String, String> added, int index) {
    setState(() {
      _entries.add(added);
    });
    return _entries;
  }

  Iterable<MapEntry<String, String>> onDeleted(
      MapEntry<String, String> deleted, int index) {
    setState(() {
      _entries.removeAt(index);
    });
    return _entries;
  }

  Iterable<MapEntry<String, String>> onReordered(int oldIndex, int newIndex) {
    setState(() {
      final key = _entries.removeAt(oldIndex);
      _entries.insert(newIndex, key);
    });
    return _entries;
  }

  FeaturePipelineParameterOrder valueTransform(Iterable<MapEntry<String, String>>? value) {
    return FeaturePipelineParameterOrder(
      name: widget.name,
      value: FeaturePipelineParameterValue(
        mapValue: MapValue(
          values: Map.fromEntries(value ?? []),
        )
      )
    );
  }
}

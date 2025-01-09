part of 'feature_pipeline_parameter_field.dart';

final class FeaturePipelineListParameterField extends StatefulWidget {
  final String name;
  final FeaturePipelineParameterOrder order;

  FeaturePipelineListParameterField({
    required this.name,
    required this.order,
  });

  @override
  State<StatefulWidget> createState() => _FeaturePipelineListParameterField();
}

final class _FeaturePipelineListParameterField
    extends State<FeaturePipelineListParameterField> {
  late final List<TextEditingController> _controllers;

  Iterable<String> get values => _controllers.map((e) => e.text);

  @override
  void initState() {
    super.initState();
    _controllers = widget.order.value.mapValue.values.keys.map((e) {
      return TextEditingController(text: e);
    }).toList();
  }

  @override
  void dispose() {
    super.dispose();
    for (final controller in _controllers) {
      controller.dispose();
    }
    _controllers.clear();
  }

  @override
  Widget build(BuildContext context) {
    return ListFromField<String>(
      name: widget.name,
      addedItialValue: "",
      initialValue: values.toList(),
      itemBuilder: (context, index, field) {
        final controller = _controllers.elementAt(index);
        return ListTile(
          title: TextField(
            controller: controller,
            onChanged: (value) {
              setState(() {
                controller.text = value;
              });
              field.didChange(values.toList());
            },
          ),
        );
      },
      onAdded: onAdded,
      onDeleted: onDeleted,
      onReordered: onReordered,
      valueTransformer: valueTransform,
    );
  }

  Iterable<String> onAdded(String added, int index) {
    setState(() {
      _controllers.add(TextEditingController(text: added));
    });
    return values;
  }

  Iterable<String> onDeleted(String deleted, int index) {
    setState(() {
      _controllers.removeAt(index);
    });
    return values;
  }

  Iterable<String> onReordered(int oldIndex, int newIndex) {
    setState(() {
      final e = _controllers.removeAt(oldIndex);
      _controllers.insert(newIndex, e);
    });
    return values;
  }

  FeaturePipelineParameterOrder valueTransform(List<String>? value) {
    return FeaturePipelineParameterOrder(
      name: widget.name,
      value: FeaturePipelineParameterValue(
        listValue: ListValue(
          values: value ?? [],
        ),
      ),
    );
  }
}

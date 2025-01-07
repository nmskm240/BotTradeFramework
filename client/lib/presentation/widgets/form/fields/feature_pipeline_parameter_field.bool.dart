part of 'feature_pipeline_parameter_field.dart';

class FeaturePipelineBoolParameterField extends FormBuilderCheckbox {
  FeaturePipelineBoolParameterField({
    required super.name,
    required FeaturePipelineParameterOrder order,
  }) : super(
          decoration: InputDecoration(
            labelText: order.name,
          ),
          title: Text(order.name),
          initialValue: order.value.boolValue,
          validator: FormBuilderValidators.compose([
            FormBuilderValidators.required(),
          ]),
          valueTransformer: (value) {
            return FeaturePipelineParameterOrder(
              name: order.name,
              value: FeaturePipelineParameterValue(
                boolValue: value,
              ),
            );
          },
        );
}

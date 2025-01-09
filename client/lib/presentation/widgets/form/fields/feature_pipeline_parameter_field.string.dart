part of 'feature_pipeline_parameter_field.dart';

class FeaturePipelineStringParameterField extends FormBuilderTextField {
  FeaturePipelineStringParameterField({
    required super.name,
    required FeaturePipelineParameterOrder order,
  }) : super(
          decoration: InputDecoration(
            labelText: order.name,
          ),
          initialValue: order.value.longValue.toString(),
          validator: FormBuilderValidators.compose([
            FormBuilderValidators.required(),
          ]),
          valueTransformer: (value) {
            return FeaturePipelineParameterOrder(
              name: order.name,
              value: FeaturePipelineParameterValue(
                stringValue: value == null ? order.value.stringValue : value,
              ),
            );
          },
        );
}

part of 'feature_pipeline_parameter_field.dart';

class FeaturePipelineLongParameterField extends FormBuilderTextField {
  FeaturePipelineLongParameterField({
    required super.name,
    required FeaturePipelineParameterOrder order,
  }) : super(
          decoration: InputDecoration(
            labelText: order.name,
          ),
          initialValue: order.value.longValue.toString(),
          validator: FormBuilderValidators.compose([
            FormBuilderValidators.required(),
            FormBuilderValidators.integer(),
          ]),
          valueTransformer: (value) {
            return FeaturePipelineParameterOrder(
              name: order.name,
              value: FeaturePipelineParameterValue(
                longValue: value == null
                    ? order.value.longValue
                    : Int64.parseInt(value),
              ),
            );
          },
        );
}

part of 'feature_pipeline_parameter_field.dart';

class FeaturePipelineDoubleParameterField extends FormBuilderTextField {
  FeaturePipelineDoubleParameterField({
    required super.name,
    required FeaturePipelineParameterOrder order,
  }) : super(
          decoration: InputDecoration(
            labelText: order.name,
          ),
          initialValue: order.value.doubleValue.toString(),
          validator: FormBuilderValidators.compose([
            FormBuilderValidators.required(),
            FormBuilderValidators.numeric(),
          ]),
          valueTransformer: (value) {
            return FeaturePipelineParameterOrder(
              name: order.name,
              value: FeaturePipelineParameterValue(
                doubleValue: value == null
                    ? order.value.doubleValue
                    : double.parse(value),
              ),
            );
          },
        );
}

// Flutter imports:
import 'package:bot_runner/presentation/widgets/key_value_field.dart';
import 'package:flutter/material.dart';

// Package imports:
import 'package:fixnum/fixnum.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';

// Project imports:
import 'package:bot_runner/application/generated/feature.pb.dart';
import 'package:bot_runner/presentation/widgets/form/fields/list_from_field.dart';

part 'feature_pipeline_parameter_field.bool.dart';
part 'feature_pipeline_parameter_field.long.dart';
part 'feature_pipeline_parameter_field.double.dart';
part 'feature_pipeline_parameter_field.string.dart';
// part 'feature_pipeline_parameter_field.range.dart';
// part 'feature_pipeline_parameter_field.select.dart';
part 'feature_pipeline_parameter_field.list.dart';
part 'feature_pipeline_parameter_field.map.dart';

class FeaturePipelineParameterField extends StatelessWidget {
  final String name;
  final FeaturePipelineParameterOrder initialValue;

  const FeaturePipelineParameterField({
    super.key,
    required this.name,
    required this.initialValue,
  });

  @override
  Widget build(BuildContext context) {
    return switch (initialValue.value.whichValue()) {
      FeaturePipelineParameterValue_Value.boolValue =>
        FeaturePipelineBoolParameterField(
          name: name,
          order: initialValue,
        ),
      FeaturePipelineParameterValue_Value.doubleValue =>
        FeaturePipelineDoubleParameterField(
          name: name,
          order: initialValue,
        ),
      FeaturePipelineParameterValue_Value.longValue =>
        FeaturePipelineLongParameterField(
          name: name,
          order: initialValue,
        ),
      FeaturePipelineParameterValue_Value.stringValue =>
        FeaturePipelineStringParameterField(
          name: name,
          order: initialValue,
        ),
      FeaturePipelineParameterValue_Value.listValue =>
        FeaturePipelineListParameterField(
          name: name,
          order: initialValue,
        ),
      FeaturePipelineParameterValue_Value.mapValue =>
        FeaturePipelineMapParameterField(
          name: name,
          order: initialValue,
        ),
      // FeaturePipelineParameterValue_Value.selectValue =>
      //   FeaturePipelineSelectParameterField(
      //     name: name,
      //     order: initialValue,
      //   ),
      // FeaturePipelineParameterValue_Value.rangeValue =>
      //   FeaturePipelineRangeParameterField(
      //     name: name,
      //     order: initialValue,
      //   ),
      _ => throw new UnimplementedError(),
    };
  }
}

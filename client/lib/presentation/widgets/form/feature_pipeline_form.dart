// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';

// Project imports:
import 'package:bot_runner/application/generated/feature.pb.dart';
import 'package:bot_runner/presentation/widgets/form/fields/feature_pipeline_parameter_field.dart';

final class FeaturePipelineForm extends StatelessWidget {
  final GlobalKey<FormBuilderState> formKey;
  final Iterable<FeaturePipelineParameterOrder> pipelineParameters;

  const FeaturePipelineForm({
    required this.formKey,
    this.pipelineParameters = const [],
  });

  @override
  Widget build(BuildContext context) {
    return FormBuilder(
      key: formKey,
      child: Column(
        children: pipelineParameters.map((e) {
          return FeaturePipelineParameterField(
            name: e.name,
            initialValue: e,
          );
        }).toList(),
      ),
    );
  }
}

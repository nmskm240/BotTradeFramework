// Flutter imports:
import 'package:bot_runner/application/services/routing_service.dart';
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/feature.pb.dart';
import 'package:bot_runner/presentation/widgets/form/feature_pipeline_form.dart';

part 'feature_pipeline_order_edit_page.state.dart';
part 'feature_pipeline_order_edit_page.notifier.dart';
part 'feature_pipeline_order_edit_page.freezed.dart';
part 'feature_pipeline_order_edit_page.g.dart';

final class FeaturePipelineOrderEditPage extends ConsumerWidget {
  late final FeaturePipelineOrderEditPageNotifierProvider provider;

  FeaturePipelineOrderEditPage({
    required GlobalKey<FormBuilderState> formKey,
    Iterable<FeaturePipelineParameterOrder> parameters = const [],
  }) {
    provider = featurePipelineOrderEditPageNotifierProvider(
      formKey: formKey,
      parameters: parameters,
    );
  }

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final state = ref.watch(provider);
    final notifier = ref.read(provider.notifier);
    return Scaffold(
      appBar: AppBar(
        actions: [
          IconButton(
            onPressed: notifier.onConfirmed,
            icon: Icon(Icons.check),
          )
        ],
      ),
      body: SingleChildScrollView(
        child: FeaturePipelineForm(
          formKey: state.formKey,
          pipelineParameters: state.parameters,
        ),
      ),
    );
  }
}

// Flutter imports:
import 'package:bot_runner/application/generated/bot.pb.dart';
import 'package:bot_runner/application/generated/exchange.pb.dart';
import 'package:bot_runner/application/services/bot_booter.dart';
import 'package:bot_runner/application/services/routing_service.dart';
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/feature.pb.dart';
import 'package:bot_runner/application/usecases/edit_feature_pipeline_usecase.dart';
import 'package:bot_runner/presentation/widgets/feature_pipeline_list_tile.dart';

part 'feature_pipeline_edit_page.state.dart';
part 'feature_pipeline_edit_page.notifier.dart';
part 'feature_pipeline_edit_page.freezed.dart';
part 'feature_pipeline_edit_page.g.dart';

final class FeaturePipelineEditPage extends ConsumerWidget {
  late final FeaturePipelineEditPageNotifierProvider provider;

  FeaturePipelineEditPage({
    Iterable<FeaturePipelineOrder> initialPipelines = const [],
  }) {
    provider = featurePipelineEditPageNotifierProvider(
      pipelines: initialPipelines,
    );
  }

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final state = ref.watch(provider);
    final notifier = ref.read(provider.notifier);
    return PopScope<Iterable<FeaturePipelineOrder>>(
      child: Scaffold(
        appBar: AppBar(
          actions: [
            IconButton(
              onPressed: notifier.onConfirmed,
              icon: Icon(Icons.check),
            ),
          ],
        ),
        floatingActionButton: FloatingActionButton(
          onPressed: notifier.onAdd,
          child: Icon(Icons.add),
        ),
        body: ReorderableListView.builder(
          itemBuilder: (context, index) {
            final pipeline = state.pipelines.elementAt(index);
            return FeaturePipelineListTile(
              key: ValueKey(index),
              pipeline: pipeline,
              onTap: () => notifier.onTappedPipelineListTile(index),
            );
          },
          itemCount: state.pipelines.length,
          onReorder: notifier.onReorder,
        ),
      ),
      canPop: false,
      onPopInvokedWithResult: notifier.onPopInvokedWithResult,
    );
  }
}

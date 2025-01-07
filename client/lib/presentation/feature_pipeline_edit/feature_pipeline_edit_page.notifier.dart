part of 'feature_pipeline_edit_page.dart';

@riverpod
class FeaturePipelineEditPageNotifier
    extends _$FeaturePipelineEditPageNotifier {
  FeaturePipelineEditPageState build({
    Iterable<FeaturePipelineOrder> pipelines = const [],
  }) {
    return FeaturePipelineEditPageState(
      pipelines: pipelines.toList(),
    );
  }

  void onAdd() async {
    final usecase = ref.read(editFeaturePipelineUsecaseProvider);
    await usecase.selectBy();
  }

  void onConfirmed() async {}

  void onReorder(int oldIndex, int newIndex) {}

  void onPopInvokedWithResult(
      bool didPop, Iterable<FeaturePipelineOrder>? result) {}

  void onTappedPipelineListTile(FeaturePipelineOrder tapped) {

  }
}

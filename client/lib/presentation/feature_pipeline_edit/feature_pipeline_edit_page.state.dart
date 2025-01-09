part of 'feature_pipeline_edit_page.dart';

@freezed
class FeaturePipelineEditPageState with _$FeaturePipelineEditPageState {
  const factory FeaturePipelineEditPageState({
    @Default([]) List<FeaturePipelineOrder> pipelines,
  }) = _FeaturePipelineEditPageState;
}

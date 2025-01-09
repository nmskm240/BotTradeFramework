part of 'feature_pipeline_order_edit_page.dart';

@freezed
class FeaturePipelineOrderEditPageState
    with _$FeaturePipelineOrderEditPageState {
  const factory FeaturePipelineOrderEditPageState({
    required GlobalKey<FormBuilderState> formKey,
    required List<FeaturePipelineParameterOrder> parameters,
  }) = _FeaturePipelineOrderEditPageState;
}

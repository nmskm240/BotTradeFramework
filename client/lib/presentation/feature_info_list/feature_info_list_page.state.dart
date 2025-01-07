part of 'feature_info_list_page.dart';

@freezed
class FeatureInfoListPageState with _$FeatureInfoListPageState {
  const factory FeatureInfoListPageState({
    @Default([]) List<FeaturePipelineInfo> infos,
  }) = _FeatureInfoListPageState;
}

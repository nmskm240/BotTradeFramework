part of 'feature_info_list_page.dart';

@riverpod
class FeatureInfoListPageNotifier extends _$FeatureInfoListPageNotifier {
  @override
  FeatureInfoListPageState build({
    Iterable<FeaturePipelineInfo> infos = const [],
  }) {
    return FeatureInfoListPageState(
      infos: infos.toList(),
    );
  }

  void onTap(FeaturePipelineInfo info) {
    final router = ref.read(routingServiceProvider);
    router.pop(res: info);
  }
}

// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/feature.pb.dart';
import 'package:bot_runner/application/services/routing_service.dart';
import 'package:bot_runner/presentation/widgets/feature_info_list_tile.dart';

part 'feature_info_list_page.state.dart';
part 'feature_info_list_page.notifier.dart';
part 'feature_info_list_page.freezed.dart';
part 'feature_info_list_page.g.dart';

class FeatureInfoListPage extends ConsumerWidget {
  late final FeatureInfoListPageNotifierProvider provider;

  FeatureInfoListPage({
    required Iterable<FeaturePipelineInfo> infos,
  }) {
    provider = featureInfoListPageNotifierProvider(infos: infos);
  }

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final state = ref.watch(provider);
    final notifier = ref.read(provider.notifier);
    return Scaffold(
      appBar: AppBar(),
      body: ListView.builder(
        itemCount: state.infos.length,
        itemBuilder: (context, index) {
          final item = state.infos.elementAt(index);
          return FeatureInfoListTile(
            info: item,
            onTap: () => notifier.onTap(item),
          );
        },
      ),
    );
  }
}

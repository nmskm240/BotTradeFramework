// Flutter imports:
import 'package:flutter/material.dart';

// Project imports:
import 'package:bot_runner/application/generated/feature.pb.dart';

final class FeatureInfoListTile extends StatelessWidget {
  final FeaturePipelineInfo info;
  final VoidCallback? onTap;

  const FeatureInfoListTile({
    required this.info,
    this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return ListTile(
      title: Text(info.name),
      onTap: onTap,
    );
  }
}

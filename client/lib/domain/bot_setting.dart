// Package imports:
import 'package:freezed_annotation/freezed_annotation.dart';

// Project imports:
import 'package:bot_runner/domain/feature_pipeline_setting.dart';

part 'bot_setting.freezed.dart';

@freezed
class BotSetting with _$BotSetting {
  const factory BotSetting({
    @Default("") String place,
    @Default("") String symbol,
    @Default([]) List<FeaturePipelineSetting> featurePipelines,
  }) = _BotSetting;
}

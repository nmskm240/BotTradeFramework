part of 'bot_detail_page.dart';

@freezed
class BotDetailPageState with _$BotDetailPageState {
  const factory BotDetailPageState({
    @Default([]) List<BotPerformance> activities,
  }) = _BotDetailPageState;
}

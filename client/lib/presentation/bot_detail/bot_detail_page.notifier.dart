part of 'bot_detail_page.dart';

@riverpod
class BotDetailPageNotifier extends _$BotDetailPageNotifier {
  @override
  BotDetailPageState build(Stream<BotPerformance> activities) {
    activities.listen(
      (e) {
        final fixed = [...state.activities, e];
        if (1000 < fixed.length) {
          fixed.removeRange(0, fixed.length - 1000);
        }
        state = state.copyWith(activities: fixed);
      },
    );
    return BotDetailPageState();
  }
}

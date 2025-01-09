// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pb.dart';
import 'package:bot_runner/application/services/bot_booter.dart';
import 'package:bot_runner/application/services/loading_overlay_service.dart';
import 'package:bot_runner/application/services/routing_service.dart';

part 'backtest_usecase.g.dart';

@riverpod
BacktestUsecase backtestUsecase(Ref ref) {
  final booter = ref.read(botBooterProvider);
  final router = ref.read(routingServiceProvider);
  final loadingOverlay = ref.read(loadingOverlayServiceProvider.notifier);
  return BacktestUsecase(booter, router, loadingOverlay);
}

final class BacktestUsecase {
  final BotBooter _booter;
  final RoutingService _router;
  final LoadingOverlayService _loadingOverlay;

  const BacktestUsecase(
    BotBooter booter,
    RoutingService router,
    LoadingOverlayService loadingOverlay,
  )   : _booter = booter,
        _router = router,
        _loadingOverlay = loadingOverlay;

  void call(BotOrder order) async {
    final activityStream = _booter.boot(order);
    await _loadingOverlay.wait(() => activityStream.first);
    await _router.replace(
      RouteName.botDetail,
      arg: BotDetailRouteArgs("0", activityStream),
    );
  }
}

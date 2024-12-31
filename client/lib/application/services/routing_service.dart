// Package imports:
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pb.dart';

part 'routing_service.dto.dart';
part 'routing_service.g.dart';

@riverpod
RoutingService routingService(Ref ref) {
  throw UnimplementedError();
}

final class RoutingService {
  final GoRouter _router;

  const RoutingService(
    GoRouter router,
  ) : _router = router;

  GoRouter get router => _router;

  Future<T?> _push<T>(
    String name, {
    Map<String, String> pathParameter = const {},
    Object? extra,
  }) async {
    return await _router.pushNamed<T>(
      name,
      pathParameters: pathParameter,
      extra: extra,
    );
  }

  Future<T?> _replace<T>(
    String name, {
    Map<String, String> pathParameter = const {},
    Object? extra,
  }) async {
    return await _router.replaceNamed(
      name,
      pathParameters: pathParameter,
      extra: extra,
    );
  }

  void pop<T>({T? res = null}) async {
    return _router.pop(res);
  }

  Future goToHome() async {
    await _router.replace(RouteName.home);
  }

  Future goToBotList() async {}

  Future goToBotEdit() async {
    await _push(RouteName.botCreate);
  }

  Future goToBotDetail({
    String id = "",
    required Stream<BotPerformance> activities,
    TransitionType transitionType = TransitionType.push,
  }) async {
    final pathParameter = {
      "id": id,
    };
    return await switch (transitionType) {
      TransitionType.push => _push(RouteName.botDetail,
          pathParameter: pathParameter, extra: activities),
      TransitionType.replace => _replace(RouteName.botDetail,
          pathParameter: pathParameter, extra: activities),
    };
  }
}

enum TransitionType {
  push,
  replace,
}

final class RouteName {
  static const String home = "home";
  static const String botList = "bots";
  static const String botCreate = "bot_create";
  static const String botDetail = "bot_detail";
  static const String featureMethodSelect = "feature_method_select";
}

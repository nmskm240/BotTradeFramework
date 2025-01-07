// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pb.dart';
import 'package:bot_runner/application/generated/exchange.pb.dart';
import 'package:bot_runner/application/generated/feature.pb.dart';

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

  Future<T?> push<T>(
    String name, {
    RoutingArgs? arg,
  }) async {
    return await _router.pushNamed<T>(
      name,
      pathParameters: arg?.pathParameters ?? {},
      extra: arg?.extra,
    );
  }

  Future<T?> replace<T>(
    String name, {
    RoutingArgs? arg,
  }) async {
    return await _router.replaceNamed(
      name,
      pathParameters: arg?.pathParameters ?? {},
      extra: arg?.extra,
    );
  }

  void pop<T>({T? res = null}) async {
    return _router.pop(res);
  }
}

final class RouteName {
  static const String home = "home";
  static const String botList = "bots";
  static const String botCreate = "bot_create";
  static const String botDetail = "bot_detail";
  static const String selectFeatures = "select_features";
  static const String selectExchanges = "select_exchanges";
  static const String selectSymbols = "select_symbols";
  static const String featuresEdit = "edit_feature";
}

// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:go_router/go_router.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

// Project imports:
import 'package:bot_runner/presentation/bot_detail/bot_detail_page.dart';
import 'package:bot_runner/presentation/bot_edit/bot_edit_page.dart';
import 'package:bot_runner/presentation/bot_list/bot_list_page.dart';
import 'package:bot_runner/presentation/feature_edit/feature_edit_page.dart';
import 'package:bot_runner/presentation/feature_method_select/feature_method_select_dialog_page.dart';
import 'package:bot_runner/presentation/home/home_page.dart';
import 'package:bot_runner/presentation/widgets/loading_overlay.dart';

part 'router.g.dart';
part 'router.dialog.dart';

final routerProvider = Provider((ref) {
  return GoRouter(
    initialLocation: "/",
    routes: $appRoutes,
  );
});

@TypedGoRoute<HomeRoute>(
  path: "/",
  name: "home",
)
final class HomeRoute extends GoRouteData {
  const HomeRoute();

  @override
  Widget build(BuildContext context, GoRouterState state) {
    return const LoadingOverlay(
      child: HomePage(),
    );
  }
}

@TypedGoRoute<BotRoute>(
  path: "/bots",
  name: "bots",
  routes: [
    TypedGoRoute<BotCreateRoute>(
      path: "/create",
      name: "bot_create",
      routes: [
        TypedGoRoute<FeatureCreateRoute>(
          path: "/features/create",
          name: "feature_create",
        ),
        TypedGoRoute<FeatureMethodSelectRoute>(
          path: "/features/select",
          name: "feature_method_select",
        ),
      ],
    ),
    TypedGoRoute<BotDetailRoute>(
      path: "/:id",
      name: "bot_detail",
    ),
    TypedGoRoute<BotEditRoute>(
      path: "/:id/edit",
      name: "bot_edit",
    ),
  ],
)
final class BotRoute extends GoRouteData {
  const BotRoute();

  @override
  Widget build(BuildContext context, GoRouterState state) {
    return const LoadingOverlay(
      child: BotListPage(),
    );
  }
}

final class BotDetailRoute extends GoRouteData {
  final String id;

  const BotDetailRoute({
    required this.id,
  });

  @override
  Widget build(BuildContext context, GoRouterState state) {
    return const LoadingOverlay(
      child: BotDeatilPage(),
    );
  }
}

final class BotEditRoute extends GoRouteData {
  final String id;

  const BotEditRoute({
    required this.id,
  });

  @override
  Widget build(BuildContext context, GoRouterState state) {
    return const LoadingOverlay(
      child: BotEditPage(),
    );
  }
}

final class BotCreateRoute extends GoRouteData {
  @override
  Widget build(BuildContext context, GoRouterState state) {
    return const LoadingOverlay(
      child: BotEditPage(),
    );
  }
}

final class FeatureMethodSelectRoute extends GoRouteData {
  @override
  Page<void> buildPage(BuildContext context, GoRouterState state) {
    return DialogPage(
      builder: (_) => const FeatureMethodSelectDialogPage(),
    );
  }
}

final class FeatureCreateRoute extends GoRouteData {
  @override
  Widget build(BuildContext context, GoRouterState state) {
    return const LoadingOverlay(
      child: FeatureEditPage(),
    );
  }
}

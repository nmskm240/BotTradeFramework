// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:go_router/go_router.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pb.dart';
import 'package:bot_runner/application/services/routing_service.dart';
import 'package:bot_runner/presentation/bot_detail/bot_detail_page.dart';
import 'package:bot_runner/presentation/bot_edit/bot_edit_page.dart';
import 'package:bot_runner/presentation/bot_list/bot_list_page.dart';
import 'package:bot_runner/presentation/feature_method_select/feature_method_select_dialog_page.dart';
import 'package:bot_runner/presentation/home/home_page.dart';
import 'package:bot_runner/presentation/widgets/loading_overlay.dart';

part 'router.g.dart';
part 'router.dialog.dart';

final routes = GoRouter(
  routes: $appRoutes,
  initialLocation: "/",
);

@TypedGoRoute<HomeRoute>(
  path: "/",
  name: RouteName.home,
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
  name: RouteName.botList,
  routes: [
    TypedGoRoute<BotCreateRoute>(
      path: "/create",
      name: RouteName.botCreate,
      routes: [
        TypedGoRoute<FeatureMethodSelectRoute>(
          path: "/features/select",
          name: RouteName.featureMethodSelect,
        ),
      ],
    ),
    TypedGoRoute<BotDetailRoute>(
      path: "/:id",
      name: RouteName.botDetail,
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
    final i = state.extra as Stream<BotPerformance>;
    return LoadingOverlay(
      child: BotDeatilPage(activities: i),
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

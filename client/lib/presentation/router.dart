// Flutter imports:
import 'package:flutter/material.dart';

// Package imports:
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:go_router/go_router.dart';

// Project imports:
import 'package:bot_runner/application/generated/bot.pb.dart';
import 'package:bot_runner/application/services/routing_service.dart';
import 'package:bot_runner/presentation/bot_detail/bot_detail_page.dart';
import 'package:bot_runner/presentation/bot_edit/bot_edit_page.dart';
import 'package:bot_runner/presentation/bot_list/bot_list_page.dart';
import 'package:bot_runner/presentation/exchange_list/exchange_list_page.dart';
import 'package:bot_runner/presentation/feature_info_list/feature_info_list_page.dart';
import 'package:bot_runner/presentation/feature_pipeline_edit/feature_pipeline_edit_page.dart';
import 'package:bot_runner/presentation/feature_pipeline_order_edit/feature_pipeline_order_edit_page.dart';
import 'package:bot_runner/presentation/home/home_page.dart';
import 'package:bot_runner/presentation/symbol_list/symbol_list_page.dart';
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
          TypedGoRoute<FeaturePipelinEditRoute>(
            path: "/features",
            name: RouteName.featuresEdit,
          ),
        ]),
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
    final extra = state.extra as BotDetailRouteExtraArgs;
    return LoadingOverlay(
      child: BotDeatilPage(activities: extra.activitiesStream),
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
    return LoadingOverlay(
      child: FeaturePipelineEditPage(
        initialPipelines: const [],
      ),
    );
  }
}

final class FeaturePipelinEditRoute extends GoRouteData {
  @override
  Widget build(BuildContext context, GoRouterState state) {
    final extra = state.extra as FeaturePipelineParameterOrderEditRouteExtraArgs;
    return LoadingOverlay(
      child: FeaturePipelineOrderEditPage(
        formKey: GlobalKey<FormBuilderState>(),
        parameters: extra.parameters,
      ),
    );
  }
}

@TypedGoRoute<SelectRoute>(
  path: "/select",
  name: "select",
  routes: [
    TypedGoRoute<SelectExchangeRoute>(
      path: "/exchanges",
      name: RouteName.selectExchanges,
    ),
    TypedGoRoute<SelectFeatureRoute>(
      path: "/features",
      name: RouteName.selectFeatures,
    ),
    TypedGoRoute<SelectSymbolRoute>(
      path: "/symbols",
      name: RouteName.selectSymbols,
    ),
  ],
)
final class SelectRoute extends GoRouteData {}

final class SelectFeatureRoute extends GoRouteData {
  @override
  Widget build(BuildContext context, GoRouterState state) {
    final extra = state.extra as FeatureInfoListExtraArgs;
    return LoadingOverlay(
      child: FeatureInfoListPage(
        infos: extra.infos,
      ),
    );
  }
}

final class SelectExchangeRoute extends GoRouteData {
  @override
  Widget build(BuildContext context, GoRouterState state) {
    final extra = state.extra as ExchangeListExtraArgs;
    return LoadingOverlay(
      child: ExchangeListPage(
        exchanges: extra.exchanges,
      ),
    );
  }
}

final class SelectSymbolRoute extends GoRouteData {
  @override
  Widget build(BuildContext context, GoRouterState state) {
    final extra = state.extra as SymbolListExtraArgs;
    return LoadingOverlay(
      child: SymbolListPage(
        symbols: extra.symbols,
      ),
    );
  }
}

// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'router.dart';

// **************************************************************************
// GoRouterGenerator
// **************************************************************************

List<RouteBase> get $appRoutes => [
      $homeRoute,
      $botRoute,
      $selectRoute,
    ];

RouteBase get $homeRoute => GoRouteData.$route(
      path: '/',
      name: 'home',
      factory: $HomeRouteExtension._fromState,
    );

extension $HomeRouteExtension on HomeRoute {
  static HomeRoute _fromState(GoRouterState state) => const HomeRoute();

  String get location => GoRouteData.$location(
        '/',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

RouteBase get $botRoute => GoRouteData.$route(
      path: '/bots',
      name: 'bots',
      factory: $BotRouteExtension._fromState,
      routes: [
        GoRouteData.$route(
          path: '/create',
          name: 'bot_create',
          factory: $BotCreateRouteExtension._fromState,
          routes: [
            GoRouteData.$route(
              path: '/features',
              name: 'edit_feature',
              factory: $FeaturePipelinEditRouteExtension._fromState,
            ),
          ],
        ),
        GoRouteData.$route(
          path: '/:id',
          name: 'bot_detail',
          factory: $BotDetailRouteExtension._fromState,
        ),
      ],
    );

extension $BotRouteExtension on BotRoute {
  static BotRoute _fromState(GoRouterState state) => const BotRoute();

  String get location => GoRouteData.$location(
        '/bots',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

extension $BotCreateRouteExtension on BotCreateRoute {
  static BotCreateRoute _fromState(GoRouterState state) => BotCreateRoute();

  String get location => GoRouteData.$location(
        '/create',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

extension $FeaturePipelinEditRouteExtension on FeaturePipelinEditRoute {
  static FeaturePipelinEditRoute _fromState(GoRouterState state) =>
      FeaturePipelinEditRoute();

  String get location => GoRouteData.$location(
        '/features',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

extension $BotDetailRouteExtension on BotDetailRoute {
  static BotDetailRoute _fromState(GoRouterState state) => BotDetailRoute(
        id: state.pathParameters['id']!,
      );

  String get location => GoRouteData.$location(
        '/${Uri.encodeComponent(id)}',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

RouteBase get $selectRoute => GoRouteData.$route(
      path: '/select',
      name: 'select',
      factory: $SelectRouteExtension._fromState,
      routes: [
        GoRouteData.$route(
          path: '/exchanges',
          name: 'select_exchanges',
          factory: $SelectExchangeRouteExtension._fromState,
        ),
        GoRouteData.$route(
          path: '/features',
          name: 'select_features',
          factory: $SelectFeatureRouteExtension._fromState,
        ),
        GoRouteData.$route(
          path: '/symbols',
          name: 'select_symbols',
          factory: $SelectSymbolRouteExtension._fromState,
        ),
      ],
    );

extension $SelectRouteExtension on SelectRoute {
  static SelectRoute _fromState(GoRouterState state) => SelectRoute();

  String get location => GoRouteData.$location(
        '/select',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

extension $SelectExchangeRouteExtension on SelectExchangeRoute {
  static SelectExchangeRoute _fromState(GoRouterState state) =>
      SelectExchangeRoute();

  String get location => GoRouteData.$location(
        '/exchanges',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

extension $SelectFeatureRouteExtension on SelectFeatureRoute {
  static SelectFeatureRoute _fromState(GoRouterState state) =>
      SelectFeatureRoute();

  String get location => GoRouteData.$location(
        '/features',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

extension $SelectSymbolRouteExtension on SelectSymbolRoute {
  static SelectSymbolRoute _fromState(GoRouterState state) =>
      SelectSymbolRoute();

  String get location => GoRouteData.$location(
        '/symbols',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

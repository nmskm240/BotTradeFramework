// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'router.dart';

// **************************************************************************
// GoRouterGenerator
// **************************************************************************

List<RouteBase> get $appRoutes => [
      $homeRoute,
      $botRoute,
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
              path: '/features/create',
              name: 'feature_create',
              factory: $FeatureCreateRouteExtension._fromState,
            ),
            GoRouteData.$route(
              path: '/features/select',
              name: 'feature_method_select',
              factory: $FeatureMethodSelectRouteExtension._fromState,
            ),
          ],
        ),
        GoRouteData.$route(
          path: '/:id',
          name: 'bot_detail',
          factory: $BotDetailRouteExtension._fromState,
        ),
        GoRouteData.$route(
          path: '/:id/edit',
          name: 'bot_edit',
          factory: $BotEditRouteExtension._fromState,
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
  static BotCreateRoute _fromState(GoRouterState state) =>
      const BotCreateRoute();

  String get location => GoRouteData.$location(
        '/create',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

extension $FeatureCreateRouteExtension on FeatureCreateRoute {
  static FeatureCreateRoute _fromState(GoRouterState state) =>
      const FeatureCreateRoute();

  String get location => GoRouteData.$location(
        '/features/create',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

extension $FeatureMethodSelectRouteExtension on FeatureMethodSelectRoute {
  static FeatureMethodSelectRoute _fromState(GoRouterState state) =>
      const FeatureMethodSelectRoute();

  String get location => GoRouteData.$location(
        '/features/select',
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

extension $BotEditRouteExtension on BotEditRoute {
  static BotEditRoute _fromState(GoRouterState state) => BotEditRoute(
        id: state.pathParameters['id']!,
      );

  String get location => GoRouteData.$location(
        '/${Uri.encodeComponent(id)}/edit',
      );

  void go(BuildContext context) => context.go(location);

  Future<T?> push<T>(BuildContext context) => context.push<T>(location);

  void pushReplacement(BuildContext context) =>
      context.pushReplacement(location);

  void replace(BuildContext context) => context.replace(location);
}

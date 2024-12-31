part of 'routing_service.dart';

abstract class RoutingArgs {
  Map<String, String> get pathParameters;
  RoutingExtraArgs get extra;
}

abstract class RoutingExtraArgs {}

final class BotDetailRouteArgs extends RoutingArgs {
  final String id;
  final Stream<BotPerformance> activitiesStream;

  BotDetailRouteArgs(this.id, this.activitiesStream);

  @override
  RoutingExtraArgs get extra => BotDetailRouteExtraArgs(activitiesStream);

  @override
  Map<String, String> get pathParameters => {"id": id};
}

final class BotDetailRouteExtraArgs extends RoutingExtraArgs {
  final Stream<BotPerformance> activitiesStream;

  BotDetailRouteExtraArgs(this.activitiesStream);
}

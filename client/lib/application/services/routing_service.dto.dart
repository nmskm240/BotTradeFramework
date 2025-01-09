part of 'routing_service.dart';

abstract class RoutingArgs {
  Map<String, String> get pathParameters;
  _RoutingExtraArgs get extra;
}

abstract class _RoutingExtraArgs {}

final class BotDetailRouteArgs extends RoutingArgs {
  final String id;
  final Stream<BotPerformance> activitiesStream;

  BotDetailRouteArgs(this.id, this.activitiesStream);

  @override
  _RoutingExtraArgs get extra => BotDetailRouteExtraArgs(activitiesStream);

  @override
  Map<String, String> get pathParameters => {"id": id};
}

final class BotDetailRouteExtraArgs extends _RoutingExtraArgs {
  final Stream<BotPerformance> activitiesStream;

  BotDetailRouteExtraArgs(this.activitiesStream);
}

final class FeaturePipelineEditRouteArgs extends RoutingArgs {
  final Iterable<FeaturePipelineOrder> pipelines;

  FeaturePipelineEditRouteArgs(this.pipelines);

  @override
  _RoutingExtraArgs get extra => FeaturePipelineEditRouteExtraArgs(pipelines);

  @override
  Map<String, String> get pathParameters => const {};
}

final class FeaturePipelineEditRouteExtraArgs extends _RoutingExtraArgs {
  final Iterable<FeaturePipelineOrder> pipelines;

  FeaturePipelineEditRouteExtraArgs(this.pipelines);
}

final class FeaturePipelineParameterOrderEditRouteArgs extends RoutingArgs {
  final Iterable<FeaturePipelineParameterOrder> parameters;

  FeaturePipelineParameterOrderEditRouteArgs(this.parameters);

  @override
  _RoutingExtraArgs get extra =>
      FeaturePipelineParameterOrderEditRouteExtraArgs(parameters);

  @override
  Map<String, String> get pathParameters => const {};
}

final class FeaturePipelineParameterOrderEditRouteExtraArgs
    extends _RoutingExtraArgs {
  final Iterable<FeaturePipelineParameterOrder> parameters;

  FeaturePipelineParameterOrderEditRouteExtraArgs(this.parameters);
}

final class ExchangeListRouteArgs extends RoutingArgs {
  final Iterable<ExchangePlace> exchanges;

  ExchangeListRouteArgs(this.exchanges);

  @override
  _RoutingExtraArgs get extra => ExchangeListExtraArgs(exchanges);

  @override
  Map<String, String> get pathParameters => const {};
}

final class ExchangeListExtraArgs extends _RoutingExtraArgs {
  final Iterable<ExchangePlace> exchanges;

  ExchangeListExtraArgs(this.exchanges);
}

final class SymbolListRouteArgs extends RoutingArgs {
  final Iterable<Symbol> symbols;

  SymbolListRouteArgs(this.symbols);

  @override
  _RoutingExtraArgs get extra => SymbolListExtraArgs(symbols);

  @override
  Map<String, String> get pathParameters => const {};
}

final class SymbolListExtraArgs extends _RoutingExtraArgs {
  final Iterable<Symbol> symbols;

  SymbolListExtraArgs(this.symbols);
}

final class FeatureInfoListRouteArgs extends RoutingArgs {
  final Iterable<FeaturePipelineInfo> infos;

  FeatureInfoListRouteArgs(this.infos);

  @override
  _RoutingExtraArgs get extra => FeatureInfoListExtraArgs(infos);

  @override
  Map<String, String> get pathParameters => const {};
}

final class FeatureInfoListExtraArgs extends _RoutingExtraArgs {
  final Iterable<FeaturePipelineInfo> infos;

  FeatureInfoListExtraArgs(this.infos);
}

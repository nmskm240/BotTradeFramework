//
//  Generated code. Do not modify.
//  source: bot.proto
//
// @dart = 2.12

// ignore_for_file: annotate_overrides, camel_case_types, comment_references
// ignore_for_file: constant_identifier_names, library_prefixes
// ignore_for_file: non_constant_identifier_names, prefer_final_fields
// ignore_for_file: unnecessary_import, unnecessary_this, unused_import

// Dart imports:
import 'dart:async' as $async;
import 'dart:core' as $core;

// Package imports:
import 'package:grpc/service_api.dart' as $grpc;
import 'package:protobuf/protobuf.dart' as $pb;

// Project imports:
import 'bot.pb.dart' as $3;

export 'bot.pb.dart';

@$pb.GrpcServiceName('bot.BotService')
class BotServiceClient extends $grpc.Client {
  static final _$run = $grpc.ClientMethod<$3.BotOrder, $3.BotPerformance>(
      '/bot.BotService/Run',
      ($3.BotOrder value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $3.BotPerformance.fromBuffer(value));

  BotServiceClient($grpc.ClientChannel channel,
      {$grpc.CallOptions? options,
      $core.Iterable<$grpc.ClientInterceptor>? interceptors})
      : super(channel, options: options,
        interceptors: interceptors);

  $grpc.ResponseStream<$3.BotPerformance> run($3.BotOrder request, {$grpc.CallOptions? options}) {
    return $createStreamingCall(_$run, $async.Stream.fromIterable([request]), options: options);
  }
}

@$pb.GrpcServiceName('bot.BotService')
abstract class BotServiceBase extends $grpc.Service {
  $core.String get $name => 'bot.BotService';

  BotServiceBase() {
    $addMethod($grpc.ServiceMethod<$3.BotOrder, $3.BotPerformance>(
        'Run',
        run_Pre,
        false,
        true,
        ($core.List<$core.int> value) => $3.BotOrder.fromBuffer(value),
        ($3.BotPerformance value) => value.writeToBuffer()));
  }

  $async.Stream<$3.BotPerformance> run_Pre($grpc.ServiceCall call, $async.Future<$3.BotOrder> request) async* {
    yield* run(call, await request);
  }

  $async.Stream<$3.BotPerformance> run($grpc.ServiceCall call, $3.BotOrder request);
}

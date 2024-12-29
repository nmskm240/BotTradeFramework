//
//  Generated code. Do not modify.
//  source: exchange.proto
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
import 'exchange.pb.dart' as $1;
import 'google/protobuf/empty.pb.dart' as $0;

export 'exchange.pb.dart';

@$pb.GrpcServiceName('exchange.ExchangeService')
class ExchangeServiceClient extends $grpc.Client {
  static final _$supportedExchanges = $grpc.ClientMethod<$0.Empty, $1.ExchangePlaces>(
      '/exchange.ExchangeService/SupportedExchanges',
      ($0.Empty value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.ExchangePlaces.fromBuffer(value));
  static final _$supportedSymbols = $grpc.ClientMethod<$1.ExchangePlace, $1.Symbols>(
      '/exchange.ExchangeService/SupportedSymbols',
      ($1.ExchangePlace value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $1.Symbols.fromBuffer(value));
  static final _$fetch = $grpc.ClientMethod<$1.Symbols, $0.Empty>(
      '/exchange.ExchangeService/Fetch',
      ($1.Symbols value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $0.Empty.fromBuffer(value));

  ExchangeServiceClient($grpc.ClientChannel channel,
      {$grpc.CallOptions? options,
      $core.Iterable<$grpc.ClientInterceptor>? interceptors})
      : super(channel, options: options,
        interceptors: interceptors);

  $grpc.ResponseFuture<$1.ExchangePlaces> supportedExchanges($0.Empty request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$supportedExchanges, request, options: options);
  }

  $grpc.ResponseFuture<$1.Symbols> supportedSymbols($1.ExchangePlace request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$supportedSymbols, request, options: options);
  }

  $grpc.ResponseFuture<$0.Empty> fetch($1.Symbols request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$fetch, request, options: options);
  }
}

@$pb.GrpcServiceName('exchange.ExchangeService')
abstract class ExchangeServiceBase extends $grpc.Service {
  $core.String get $name => 'exchange.ExchangeService';

  ExchangeServiceBase() {
    $addMethod($grpc.ServiceMethod<$0.Empty, $1.ExchangePlaces>(
        'SupportedExchanges',
        supportedExchanges_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $0.Empty.fromBuffer(value),
        ($1.ExchangePlaces value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.ExchangePlace, $1.Symbols>(
        'SupportedSymbols',
        supportedSymbols_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.ExchangePlace.fromBuffer(value),
        ($1.Symbols value) => value.writeToBuffer()));
    $addMethod($grpc.ServiceMethod<$1.Symbols, $0.Empty>(
        'Fetch',
        fetch_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $1.Symbols.fromBuffer(value),
        ($0.Empty value) => value.writeToBuffer()));
  }

  $async.Future<$1.ExchangePlaces> supportedExchanges_Pre($grpc.ServiceCall call, $async.Future<$0.Empty> request) async {
    return supportedExchanges(call, await request);
  }

  $async.Future<$1.Symbols> supportedSymbols_Pre($grpc.ServiceCall call, $async.Future<$1.ExchangePlace> request) async {
    return supportedSymbols(call, await request);
  }

  $async.Future<$0.Empty> fetch_Pre($grpc.ServiceCall call, $async.Future<$1.Symbols> request) async {
    return fetch(call, await request);
  }

  $async.Future<$1.ExchangePlaces> supportedExchanges($grpc.ServiceCall call, $0.Empty request);
  $async.Future<$1.Symbols> supportedSymbols($grpc.ServiceCall call, $1.ExchangePlace request);
  $async.Future<$0.Empty> fetch($grpc.ServiceCall call, $1.Symbols request);
}

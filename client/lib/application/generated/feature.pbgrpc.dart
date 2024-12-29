//
//  Generated code. Do not modify.
//  source: feature.proto
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
import 'feature.pb.dart' as $2;
import 'google/protobuf/empty.pb.dart' as $0;

export 'feature.pb.dart';

@$pb.GrpcServiceName('feature.FeatureService')
class FeatureServiceClient extends $grpc.Client {
  static final _$supportedFeaturePipelines = $grpc.ClientMethod<$0.Empty, $2.FeaturePipelineInfos>(
      '/feature.FeatureService/SupportedFeaturePipelines',
      ($0.Empty value) => value.writeToBuffer(),
      ($core.List<$core.int> value) => $2.FeaturePipelineInfos.fromBuffer(value));

  FeatureServiceClient($grpc.ClientChannel channel,
      {$grpc.CallOptions? options,
      $core.Iterable<$grpc.ClientInterceptor>? interceptors})
      : super(channel, options: options,
        interceptors: interceptors);

  $grpc.ResponseFuture<$2.FeaturePipelineInfos> supportedFeaturePipelines($0.Empty request, {$grpc.CallOptions? options}) {
    return $createUnaryCall(_$supportedFeaturePipelines, request, options: options);
  }
}

@$pb.GrpcServiceName('feature.FeatureService')
abstract class FeatureServiceBase extends $grpc.Service {
  $core.String get $name => 'feature.FeatureService';

  FeatureServiceBase() {
    $addMethod($grpc.ServiceMethod<$0.Empty, $2.FeaturePipelineInfos>(
        'SupportedFeaturePipelines',
        supportedFeaturePipelines_Pre,
        false,
        false,
        ($core.List<$core.int> value) => $0.Empty.fromBuffer(value),
        ($2.FeaturePipelineInfos value) => value.writeToBuffer()));
  }

  $async.Future<$2.FeaturePipelineInfos> supportedFeaturePipelines_Pre($grpc.ServiceCall call, $async.Future<$0.Empty> request) async {
    return supportedFeaturePipelines(call, await request);
  }

  $async.Future<$2.FeaturePipelineInfos> supportedFeaturePipelines($grpc.ServiceCall call, $0.Empty request);
}

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
import 'dart:convert' as $convert;
import 'dart:core' as $core;
import 'dart:typed_data' as $typed_data;

@$core.Deprecated('Use botPerformanceDescriptor instead')
const BotPerformance$json = {
  '1': 'BotPerformance',
  '2': [
    {'1': 'predict_value', '3': 1, '4': 1, '5': 1, '10': 'predictValue'},
    {'1': 'actual_value', '3': 2, '4': 1, '5': 1, '10': 'actualValue'},
    {'1': 'timestamp', '3': 3, '4': 1, '5': 11, '6': '.google.protobuf.Timestamp', '10': 'timestamp'},
  ],
};

/// Descriptor for `BotPerformance`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List botPerformanceDescriptor = $convert.base64Decode(
    'Cg5Cb3RQZXJmb3JtYW5jZRIjCg1wcmVkaWN0X3ZhbHVlGAEgASgBUgxwcmVkaWN0VmFsdWUSIQ'
    'oMYWN0dWFsX3ZhbHVlGAIgASgBUgthY3R1YWxWYWx1ZRI4Cgl0aW1lc3RhbXAYAyABKAsyGi5n'
    'b29nbGUucHJvdG9idWYuVGltZXN0YW1wUgl0aW1lc3RhbXA=');

@$core.Deprecated('Use botOrderDescriptor instead')
const BotOrder$json = {
  '1': 'BotOrder',
  '2': [
    {'1': 'symbol', '3': 1, '4': 1, '5': 11, '6': '.exchange.Symbol', '10': 'symbol'},
    {'1': 'pipeline_orders', '3': 2, '4': 3, '5': 11, '6': '.feature.FeaturePipelineOrder', '10': 'pipelineOrders'},
    {'1': 'start_at', '3': 3, '4': 1, '5': 11, '6': '.google.protobuf.Timestamp', '9': 0, '10': 'startAt', '17': true},
    {'1': 'end_at', '3': 4, '4': 1, '5': 11, '6': '.google.protobuf.Timestamp', '9': 1, '10': 'endAt', '17': true},
  ],
  '8': [
    {'1': '_start_at'},
    {'1': '_end_at'},
  ],
};

/// Descriptor for `BotOrder`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List botOrderDescriptor = $convert.base64Decode(
    'CghCb3RPcmRlchIoCgZzeW1ib2wYASABKAsyEC5leGNoYW5nZS5TeW1ib2xSBnN5bWJvbBJGCg'
    '9waXBlbGluZV9vcmRlcnMYAiADKAsyHS5mZWF0dXJlLkZlYXR1cmVQaXBlbGluZU9yZGVyUg5w'
    'aXBlbGluZU9yZGVycxI6CghzdGFydF9hdBgDIAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3'
    'RhbXBIAFIHc3RhcnRBdIgBARI2CgZlbmRfYXQYBCABKAsyGi5nb29nbGUucHJvdG9idWYuVGlt'
    'ZXN0YW1wSAFSBWVuZEF0iAEBQgsKCV9zdGFydF9hdEIJCgdfZW5kX2F0');


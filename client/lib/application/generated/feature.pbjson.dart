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
import 'dart:convert' as $convert;
import 'dart:core' as $core;
import 'dart:typed_data' as $typed_data;

@$core.Deprecated('Use featurePipelineInfosDescriptor instead')
const FeaturePipelineInfos$json = {
  '1': 'FeaturePipelineInfos',
  '2': [
    {'1': 'infos', '3': 1, '4': 3, '5': 11, '6': '.feature.FeaturePipelineInfo', '10': 'infos'},
  ],
};

/// Descriptor for `FeaturePipelineInfos`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List featurePipelineInfosDescriptor = $convert.base64Decode(
    'ChRGZWF0dXJlUGlwZWxpbmVJbmZvcxIyCgVpbmZvcxgBIAMoCzIcLmZlYXR1cmUuRmVhdHVyZV'
    'BpcGVsaW5lSW5mb1IFaW5mb3M=');

@$core.Deprecated('Use featurePipelineInfoDescriptor instead')
const FeaturePipelineInfo$json = {
  '1': 'FeaturePipelineInfo',
  '2': [
    {'1': 'type', '3': 1, '4': 1, '5': 9, '10': 'type'},
    {'1': 'name', '3': 2, '4': 1, '5': 9, '10': 'name'},
    {'1': 'description', '3': 3, '4': 1, '5': 9, '10': 'description'},
    {'1': 'parameters', '3': 4, '4': 3, '5': 11, '6': '.feature.FeaturePipelineParameterInfo', '10': 'parameters'},
  ],
};

/// Descriptor for `FeaturePipelineInfo`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List featurePipelineInfoDescriptor = $convert.base64Decode(
    'ChNGZWF0dXJlUGlwZWxpbmVJbmZvEhIKBHR5cGUYASABKAlSBHR5cGUSEgoEbmFtZRgCIAEoCV'
    'IEbmFtZRIgCgtkZXNjcmlwdGlvbhgDIAEoCVILZGVzY3JpcHRpb24SRQoKcGFyYW1ldGVycxgE'
    'IAMoCzIlLmZlYXR1cmUuRmVhdHVyZVBpcGVsaW5lUGFyYW1ldGVySW5mb1IKcGFyYW1ldGVycw'
    '==');

@$core.Deprecated('Use featurePipelineParameterInfoDescriptor instead')
const FeaturePipelineParameterInfo$json = {
  '1': 'FeaturePipelineParameterInfo',
  '2': [
    {'1': 'name', '3': 1, '4': 1, '5': 9, '10': 'name'},
    {'1': 'description', '3': 2, '4': 1, '5': 9, '10': 'description'},
    {'1': 'default_value', '3': 3, '4': 1, '5': 11, '6': '.feature.FeaturePipelineParameterValue', '10': 'defaultValue'},
  ],
};

/// Descriptor for `FeaturePipelineParameterInfo`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List featurePipelineParameterInfoDescriptor = $convert.base64Decode(
    'ChxGZWF0dXJlUGlwZWxpbmVQYXJhbWV0ZXJJbmZvEhIKBG5hbWUYASABKAlSBG5hbWUSIAoLZG'
    'VzY3JpcHRpb24YAiABKAlSC2Rlc2NyaXB0aW9uEksKDWRlZmF1bHRfdmFsdWUYAyABKAsyJi5m'
    'ZWF0dXJlLkZlYXR1cmVQaXBlbGluZVBhcmFtZXRlclZhbHVlUgxkZWZhdWx0VmFsdWU=');

@$core.Deprecated('Use featurePipelineOrderDescriptor instead')
const FeaturePipelineOrder$json = {
  '1': 'FeaturePipelineOrder',
  '2': [
    {'1': 'type', '3': 1, '4': 1, '5': 9, '10': 'type'},
    {'1': 'parameters', '3': 2, '4': 3, '5': 11, '6': '.feature.FeaturePipelineParameterOrder', '10': 'parameters'},
  ],
};

/// Descriptor for `FeaturePipelineOrder`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List featurePipelineOrderDescriptor = $convert.base64Decode(
    'ChRGZWF0dXJlUGlwZWxpbmVPcmRlchISCgR0eXBlGAEgASgJUgR0eXBlEkYKCnBhcmFtZXRlcn'
    'MYAiADKAsyJi5mZWF0dXJlLkZlYXR1cmVQaXBlbGluZVBhcmFtZXRlck9yZGVyUgpwYXJhbWV0'
    'ZXJz');

@$core.Deprecated('Use featurePipelineParameterOrderDescriptor instead')
const FeaturePipelineParameterOrder$json = {
  '1': 'FeaturePipelineParameterOrder',
  '2': [
    {'1': 'name', '3': 1, '4': 1, '5': 9, '10': 'name'},
    {'1': 'value', '3': 2, '4': 1, '5': 11, '6': '.feature.FeaturePipelineParameterValue', '10': 'value'},
  ],
};

/// Descriptor for `FeaturePipelineParameterOrder`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List featurePipelineParameterOrderDescriptor = $convert.base64Decode(
    'Ch1GZWF0dXJlUGlwZWxpbmVQYXJhbWV0ZXJPcmRlchISCgRuYW1lGAEgASgJUgRuYW1lEjwKBX'
    'ZhbHVlGAIgASgLMiYuZmVhdHVyZS5GZWF0dXJlUGlwZWxpbmVQYXJhbWV0ZXJWYWx1ZVIFdmFs'
    'dWU=');

@$core.Deprecated('Use featurePipelineParameterValueDescriptor instead')
const FeaturePipelineParameterValue$json = {
  '1': 'FeaturePipelineParameterValue',
  '2': [
    {'1': 'string_value', '3': 1, '4': 1, '5': 9, '9': 0, '10': 'stringValue'},
    {'1': 'long_value', '3': 2, '4': 1, '5': 3, '9': 0, '10': 'longValue'},
    {'1': 'double_value', '3': 3, '4': 1, '5': 1, '9': 0, '10': 'doubleValue'},
    {'1': 'bool_value', '3': 4, '4': 1, '5': 8, '9': 0, '10': 'boolValue'},
    {'1': 'list_value', '3': 5, '4': 1, '5': 11, '6': '.feature.ListValue', '9': 0, '10': 'listValue'},
    {'1': 'select_value', '3': 6, '4': 1, '5': 11, '6': '.feature.SelectValue', '9': 0, '10': 'selectValue'},
    {'1': 'map_value', '3': 7, '4': 1, '5': 11, '6': '.feature.MapValue', '9': 0, '10': 'mapValue'},
    {'1': 'range_value', '3': 8, '4': 1, '5': 11, '6': '.feature.RangeValue', '9': 0, '10': 'rangeValue'},
  ],
  '8': [
    {'1': 'value'},
  ],
};

/// Descriptor for `FeaturePipelineParameterValue`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List featurePipelineParameterValueDescriptor = $convert.base64Decode(
    'Ch1GZWF0dXJlUGlwZWxpbmVQYXJhbWV0ZXJWYWx1ZRIjCgxzdHJpbmdfdmFsdWUYASABKAlIAF'
    'ILc3RyaW5nVmFsdWUSHwoKbG9uZ192YWx1ZRgCIAEoA0gAUglsb25nVmFsdWUSIwoMZG91Ymxl'
    'X3ZhbHVlGAMgASgBSABSC2RvdWJsZVZhbHVlEh8KCmJvb2xfdmFsdWUYBCABKAhIAFIJYm9vbF'
    'ZhbHVlEjMKCmxpc3RfdmFsdWUYBSABKAsyEi5mZWF0dXJlLkxpc3RWYWx1ZUgAUglsaXN0VmFs'
    'dWUSOQoMc2VsZWN0X3ZhbHVlGAYgASgLMhQuZmVhdHVyZS5TZWxlY3RWYWx1ZUgAUgtzZWxlY3'
    'RWYWx1ZRIwCgltYXBfdmFsdWUYByABKAsyES5mZWF0dXJlLk1hcFZhbHVlSABSCG1hcFZhbHVl'
    'EjYKC3JhbmdlX3ZhbHVlGAggASgLMhMuZmVhdHVyZS5SYW5nZVZhbHVlSABSCnJhbmdlVmFsdW'
    'VCBwoFdmFsdWU=');

@$core.Deprecated('Use listValueDescriptor instead')
const ListValue$json = {
  '1': 'ListValue',
  '2': [
    {'1': 'values', '3': 1, '4': 3, '5': 9, '10': 'values'},
  ],
};

/// Descriptor for `ListValue`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List listValueDescriptor = $convert.base64Decode(
    'CglMaXN0VmFsdWUSFgoGdmFsdWVzGAEgAygJUgZ2YWx1ZXM=');

@$core.Deprecated('Use selectValueDescriptor instead')
const SelectValue$json = {
  '1': 'SelectValue',
  '2': [
    {'1': 'value', '3': 1, '4': 1, '5': 9, '10': 'value'},
    {'1': 'options', '3': 2, '4': 3, '5': 9, '10': 'options'},
  ],
};

/// Descriptor for `SelectValue`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List selectValueDescriptor = $convert.base64Decode(
    'CgtTZWxlY3RWYWx1ZRIUCgV2YWx1ZRgBIAEoCVIFdmFsdWUSGAoHb3B0aW9ucxgCIAMoCVIHb3'
    'B0aW9ucw==');

@$core.Deprecated('Use mapValueDescriptor instead')
const MapValue$json = {
  '1': 'MapValue',
  '2': [
    {'1': 'values', '3': 1, '4': 3, '5': 11, '6': '.feature.MapValue.ValuesEntry', '10': 'values'},
    {'1': 'selectable_keys', '3': 2, '4': 1, '5': 11, '6': '.feature.SelectValue', '9': 0, '10': 'selectableKeys', '17': true},
    {'1': 'selectable_values', '3': 3, '4': 1, '5': 11, '6': '.feature.SelectValue', '9': 1, '10': 'selectableValues', '17': true},
  ],
  '3': [MapValue_ValuesEntry$json],
  '8': [
    {'1': '_selectable_keys'},
    {'1': '_selectable_values'},
  ],
};

@$core.Deprecated('Use mapValueDescriptor instead')
const MapValue_ValuesEntry$json = {
  '1': 'ValuesEntry',
  '2': [
    {'1': 'key', '3': 1, '4': 1, '5': 9, '10': 'key'},
    {'1': 'value', '3': 2, '4': 1, '5': 9, '10': 'value'},
  ],
  '7': {'7': true},
};

/// Descriptor for `MapValue`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List mapValueDescriptor = $convert.base64Decode(
    'CghNYXBWYWx1ZRI1CgZ2YWx1ZXMYASADKAsyHS5mZWF0dXJlLk1hcFZhbHVlLlZhbHVlc0VudH'
    'J5UgZ2YWx1ZXMSQgoPc2VsZWN0YWJsZV9rZXlzGAIgASgLMhQuZmVhdHVyZS5TZWxlY3RWYWx1'
    'ZUgAUg5zZWxlY3RhYmxlS2V5c4gBARJGChFzZWxlY3RhYmxlX3ZhbHVlcxgDIAEoCzIULmZlYX'
    'R1cmUuU2VsZWN0VmFsdWVIAVIQc2VsZWN0YWJsZVZhbHVlc4gBARo5CgtWYWx1ZXNFbnRyeRIQ'
    'CgNrZXkYASABKAlSA2tleRIUCgV2YWx1ZRgCIAEoCVIFdmFsdWU6AjgBQhIKEF9zZWxlY3RhYm'
    'xlX2tleXNCFAoSX3NlbGVjdGFibGVfdmFsdWVz');

@$core.Deprecated('Use rangeValueDescriptor instead')
const RangeValue$json = {
  '1': 'RangeValue',
  '2': [
    {'1': 'value', '3': 1, '4': 1, '5': 1, '10': 'value'},
    {'1': 'min', '3': 2, '4': 1, '5': 1, '10': 'min'},
    {'1': 'max', '3': 3, '4': 1, '5': 1, '10': 'max'},
  ],
};

/// Descriptor for `RangeValue`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List rangeValueDescriptor = $convert.base64Decode(
    'CgpSYW5nZVZhbHVlEhQKBXZhbHVlGAEgASgBUgV2YWx1ZRIQCgNtaW4YAiABKAFSA21pbhIQCg'
    'NtYXgYAyABKAFSA21heA==');


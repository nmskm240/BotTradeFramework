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
import 'dart:convert' as $convert;
import 'dart:core' as $core;
import 'dart:typed_data' as $typed_data;

@$core.Deprecated('Use symbolDescriptor instead')
const Symbol$json = {
  '1': 'Symbol',
  '2': [
    {'1': 'code', '3': 1, '4': 1, '5': 9, '10': 'code'},
    {'1': 'name', '3': 2, '4': 1, '5': 9, '10': 'name'},
    {'1': 'place', '3': 3, '4': 1, '5': 11, '6': '.exchange.ExchangePlace', '10': 'place'},
  ],
};

/// Descriptor for `Symbol`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List symbolDescriptor = $convert.base64Decode(
    'CgZTeW1ib2wSEgoEY29kZRgBIAEoCVIEY29kZRISCgRuYW1lGAIgASgJUgRuYW1lEi0KBXBsYW'
    'NlGAMgASgLMhcuZXhjaGFuZ2UuRXhjaGFuZ2VQbGFjZVIFcGxhY2U=');

@$core.Deprecated('Use symbolsDescriptor instead')
const Symbols$json = {
  '1': 'Symbols',
  '2': [
    {'1': 'symbols', '3': 1, '4': 3, '5': 11, '6': '.exchange.Symbol', '10': 'symbols'},
  ],
};

/// Descriptor for `Symbols`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List symbolsDescriptor = $convert.base64Decode(
    'CgdTeW1ib2xzEioKB3N5bWJvbHMYASADKAsyEC5leGNoYW5nZS5TeW1ib2xSB3N5bWJvbHM=');

@$core.Deprecated('Use exchangePlaceDescriptor instead')
const ExchangePlace$json = {
  '1': 'ExchangePlace',
  '2': [
    {'1': 'name', '3': 1, '4': 1, '5': 9, '10': 'name'},
    {'1': 'isBacktest', '3': 2, '4': 1, '5': 8, '10': 'isBacktest'},
  ],
};

/// Descriptor for `ExchangePlace`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List exchangePlaceDescriptor = $convert.base64Decode(
    'Cg1FeGNoYW5nZVBsYWNlEhIKBG5hbWUYASABKAlSBG5hbWUSHgoKaXNCYWNrdGVzdBgCIAEoCF'
    'IKaXNCYWNrdGVzdA==');

@$core.Deprecated('Use exchangePlacesDescriptor instead')
const ExchangePlaces$json = {
  '1': 'ExchangePlaces',
  '2': [
    {'1': 'places', '3': 1, '4': 3, '5': 11, '6': '.exchange.ExchangePlace', '10': 'places'},
  ],
};

/// Descriptor for `ExchangePlaces`. Decode as a `google.protobuf.DescriptorProto`.
final $typed_data.Uint8List exchangePlacesDescriptor = $convert.base64Decode(
    'Cg5FeGNoYW5nZVBsYWNlcxIvCgZwbGFjZXMYASADKAsyFy5leGNoYW5nZS5FeGNoYW5nZVBsYW'
    'NlUgZwbGFjZXM=');


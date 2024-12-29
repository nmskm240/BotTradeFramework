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
import 'dart:core' as $core;

// Package imports:
import 'package:protobuf/protobuf.dart' as $pb;

// Project imports:
import 'exchange.pb.dart' as $1;
import 'feature.pb.dart' as $2;
import 'google/protobuf/timestamp.pb.dart' as $4;

class BotPerformance extends $pb.GeneratedMessage {
  factory BotPerformance({
    $core.double? predictValue,
    $core.double? actualValue,
    $4.Timestamp? timestamp,
  }) {
    final $result = create();
    if (predictValue != null) {
      $result.predictValue = predictValue;
    }
    if (actualValue != null) {
      $result.actualValue = actualValue;
    }
    if (timestamp != null) {
      $result.timestamp = timestamp;
    }
    return $result;
  }
  BotPerformance._() : super();
  factory BotPerformance.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory BotPerformance.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'BotPerformance', package: const $pb.PackageName(_omitMessageNames ? '' : 'bot'), createEmptyInstance: create)
    ..a<$core.double>(1, _omitFieldNames ? '' : 'predictValue', $pb.PbFieldType.OD)
    ..a<$core.double>(2, _omitFieldNames ? '' : 'actualValue', $pb.PbFieldType.OD)
    ..aOM<$4.Timestamp>(3, _omitFieldNames ? '' : 'timestamp', subBuilder: $4.Timestamp.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  BotPerformance clone() => BotPerformance()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  BotPerformance copyWith(void Function(BotPerformance) updates) => super.copyWith((message) => updates(message as BotPerformance)) as BotPerformance;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static BotPerformance create() => BotPerformance._();
  BotPerformance createEmptyInstance() => create();
  static $pb.PbList<BotPerformance> createRepeated() => $pb.PbList<BotPerformance>();
  @$core.pragma('dart2js:noInline')
  static BotPerformance getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<BotPerformance>(create);
  static BotPerformance? _defaultInstance;

  @$pb.TagNumber(1)
  $core.double get predictValue => $_getN(0);
  @$pb.TagNumber(1)
  set predictValue($core.double v) { $_setDouble(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasPredictValue() => $_has(0);
  @$pb.TagNumber(1)
  void clearPredictValue() => clearField(1);

  @$pb.TagNumber(2)
  $core.double get actualValue => $_getN(1);
  @$pb.TagNumber(2)
  set actualValue($core.double v) { $_setDouble(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasActualValue() => $_has(1);
  @$pb.TagNumber(2)
  void clearActualValue() => clearField(2);

  @$pb.TagNumber(3)
  $4.Timestamp get timestamp => $_getN(2);
  @$pb.TagNumber(3)
  set timestamp($4.Timestamp v) { setField(3, v); }
  @$pb.TagNumber(3)
  $core.bool hasTimestamp() => $_has(2);
  @$pb.TagNumber(3)
  void clearTimestamp() => clearField(3);
  @$pb.TagNumber(3)
  $4.Timestamp ensureTimestamp() => $_ensure(2);
}

class BotOrder extends $pb.GeneratedMessage {
  factory BotOrder({
    $1.Symbol? symbol,
    $core.Iterable<$2.FeaturePipelineOrder>? pipelineOrders,
    $4.Timestamp? startAt,
    $4.Timestamp? endAt,
  }) {
    final $result = create();
    if (symbol != null) {
      $result.symbol = symbol;
    }
    if (pipelineOrders != null) {
      $result.pipelineOrders.addAll(pipelineOrders);
    }
    if (startAt != null) {
      $result.startAt = startAt;
    }
    if (endAt != null) {
      $result.endAt = endAt;
    }
    return $result;
  }
  BotOrder._() : super();
  factory BotOrder.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory BotOrder.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'BotOrder', package: const $pb.PackageName(_omitMessageNames ? '' : 'bot'), createEmptyInstance: create)
    ..aOM<$1.Symbol>(1, _omitFieldNames ? '' : 'symbol', subBuilder: $1.Symbol.create)
    ..pc<$2.FeaturePipelineOrder>(2, _omitFieldNames ? '' : 'pipelineOrders', $pb.PbFieldType.PM, subBuilder: $2.FeaturePipelineOrder.create)
    ..aOM<$4.Timestamp>(3, _omitFieldNames ? '' : 'startAt', subBuilder: $4.Timestamp.create)
    ..aOM<$4.Timestamp>(4, _omitFieldNames ? '' : 'endAt', subBuilder: $4.Timestamp.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  BotOrder clone() => BotOrder()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  BotOrder copyWith(void Function(BotOrder) updates) => super.copyWith((message) => updates(message as BotOrder)) as BotOrder;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static BotOrder create() => BotOrder._();
  BotOrder createEmptyInstance() => create();
  static $pb.PbList<BotOrder> createRepeated() => $pb.PbList<BotOrder>();
  @$core.pragma('dart2js:noInline')
  static BotOrder getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<BotOrder>(create);
  static BotOrder? _defaultInstance;

  @$pb.TagNumber(1)
  $1.Symbol get symbol => $_getN(0);
  @$pb.TagNumber(1)
  set symbol($1.Symbol v) { setField(1, v); }
  @$pb.TagNumber(1)
  $core.bool hasSymbol() => $_has(0);
  @$pb.TagNumber(1)
  void clearSymbol() => clearField(1);
  @$pb.TagNumber(1)
  $1.Symbol ensureSymbol() => $_ensure(0);

  @$pb.TagNumber(2)
  $core.List<$2.FeaturePipelineOrder> get pipelineOrders => $_getList(1);

  @$pb.TagNumber(3)
  $4.Timestamp get startAt => $_getN(2);
  @$pb.TagNumber(3)
  set startAt($4.Timestamp v) { setField(3, v); }
  @$pb.TagNumber(3)
  $core.bool hasStartAt() => $_has(2);
  @$pb.TagNumber(3)
  void clearStartAt() => clearField(3);
  @$pb.TagNumber(3)
  $4.Timestamp ensureStartAt() => $_ensure(2);

  @$pb.TagNumber(4)
  $4.Timestamp get endAt => $_getN(3);
  @$pb.TagNumber(4)
  set endAt($4.Timestamp v) { setField(4, v); }
  @$pb.TagNumber(4)
  $core.bool hasEndAt() => $_has(3);
  @$pb.TagNumber(4)
  void clearEndAt() => clearField(4);
  @$pb.TagNumber(4)
  $4.Timestamp ensureEndAt() => $_ensure(3);
}


const _omitFieldNames = $core.bool.fromEnvironment('protobuf.omit_field_names');
const _omitMessageNames = $core.bool.fromEnvironment('protobuf.omit_message_names');

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
import 'dart:core' as $core;

// Package imports:
import 'package:fixnum/fixnum.dart' as $fixnum;
import 'package:protobuf/protobuf.dart' as $pb;

class FeaturePipelineInfos extends $pb.GeneratedMessage {
  factory FeaturePipelineInfos({
    $core.Iterable<FeaturePipelineInfo>? infos,
  }) {
    final $result = create();
    if (infos != null) {
      $result.infos.addAll(infos);
    }
    return $result;
  }
  FeaturePipelineInfos._() : super();
  factory FeaturePipelineInfos.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory FeaturePipelineInfos.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'FeaturePipelineInfos', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..pc<FeaturePipelineInfo>(1, _omitFieldNames ? '' : 'infos', $pb.PbFieldType.PM, subBuilder: FeaturePipelineInfo.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  FeaturePipelineInfos clone() => FeaturePipelineInfos()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  FeaturePipelineInfos copyWith(void Function(FeaturePipelineInfos) updates) => super.copyWith((message) => updates(message as FeaturePipelineInfos)) as FeaturePipelineInfos;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static FeaturePipelineInfos create() => FeaturePipelineInfos._();
  FeaturePipelineInfos createEmptyInstance() => create();
  static $pb.PbList<FeaturePipelineInfos> createRepeated() => $pb.PbList<FeaturePipelineInfos>();
  @$core.pragma('dart2js:noInline')
  static FeaturePipelineInfos getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<FeaturePipelineInfos>(create);
  static FeaturePipelineInfos? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<FeaturePipelineInfo> get infos => $_getList(0);
}

class FeaturePipelineInfo extends $pb.GeneratedMessage {
  factory FeaturePipelineInfo({
    $core.String? type,
    $core.String? name,
    $core.String? description,
    $core.Iterable<FeaturePipelineParameterInfo>? parameters,
  }) {
    final $result = create();
    if (type != null) {
      $result.type = type;
    }
    if (name != null) {
      $result.name = name;
    }
    if (description != null) {
      $result.description = description;
    }
    if (parameters != null) {
      $result.parameters.addAll(parameters);
    }
    return $result;
  }
  FeaturePipelineInfo._() : super();
  factory FeaturePipelineInfo.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory FeaturePipelineInfo.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'FeaturePipelineInfo', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'type')
    ..aOS(2, _omitFieldNames ? '' : 'name')
    ..aOS(3, _omitFieldNames ? '' : 'description')
    ..pc<FeaturePipelineParameterInfo>(4, _omitFieldNames ? '' : 'parameters', $pb.PbFieldType.PM, subBuilder: FeaturePipelineParameterInfo.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  FeaturePipelineInfo clone() => FeaturePipelineInfo()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  FeaturePipelineInfo copyWith(void Function(FeaturePipelineInfo) updates) => super.copyWith((message) => updates(message as FeaturePipelineInfo)) as FeaturePipelineInfo;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static FeaturePipelineInfo create() => FeaturePipelineInfo._();
  FeaturePipelineInfo createEmptyInstance() => create();
  static $pb.PbList<FeaturePipelineInfo> createRepeated() => $pb.PbList<FeaturePipelineInfo>();
  @$core.pragma('dart2js:noInline')
  static FeaturePipelineInfo getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<FeaturePipelineInfo>(create);
  static FeaturePipelineInfo? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get type => $_getSZ(0);
  @$pb.TagNumber(1)
  set type($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasType() => $_has(0);
  @$pb.TagNumber(1)
  void clearType() => clearField(1);

  @$pb.TagNumber(2)
  $core.String get name => $_getSZ(1);
  @$pb.TagNumber(2)
  set name($core.String v) { $_setString(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasName() => $_has(1);
  @$pb.TagNumber(2)
  void clearName() => clearField(2);

  @$pb.TagNumber(3)
  $core.String get description => $_getSZ(2);
  @$pb.TagNumber(3)
  set description($core.String v) { $_setString(2, v); }
  @$pb.TagNumber(3)
  $core.bool hasDescription() => $_has(2);
  @$pb.TagNumber(3)
  void clearDescription() => clearField(3);

  @$pb.TagNumber(4)
  $core.List<FeaturePipelineParameterInfo> get parameters => $_getList(3);
}

class FeaturePipelineParameterInfo extends $pb.GeneratedMessage {
  factory FeaturePipelineParameterInfo({
    $core.String? name,
    $core.String? description,
    FeaturePipelineParameterValue? defaultValue,
  }) {
    final $result = create();
    if (name != null) {
      $result.name = name;
    }
    if (description != null) {
      $result.description = description;
    }
    if (defaultValue != null) {
      $result.defaultValue = defaultValue;
    }
    return $result;
  }
  FeaturePipelineParameterInfo._() : super();
  factory FeaturePipelineParameterInfo.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory FeaturePipelineParameterInfo.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'FeaturePipelineParameterInfo', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'name')
    ..aOS(2, _omitFieldNames ? '' : 'description')
    ..aOM<FeaturePipelineParameterValue>(3, _omitFieldNames ? '' : 'defaultValue', subBuilder: FeaturePipelineParameterValue.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  FeaturePipelineParameterInfo clone() => FeaturePipelineParameterInfo()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  FeaturePipelineParameterInfo copyWith(void Function(FeaturePipelineParameterInfo) updates) => super.copyWith((message) => updates(message as FeaturePipelineParameterInfo)) as FeaturePipelineParameterInfo;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static FeaturePipelineParameterInfo create() => FeaturePipelineParameterInfo._();
  FeaturePipelineParameterInfo createEmptyInstance() => create();
  static $pb.PbList<FeaturePipelineParameterInfo> createRepeated() => $pb.PbList<FeaturePipelineParameterInfo>();
  @$core.pragma('dart2js:noInline')
  static FeaturePipelineParameterInfo getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<FeaturePipelineParameterInfo>(create);
  static FeaturePipelineParameterInfo? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get name => $_getSZ(0);
  @$pb.TagNumber(1)
  set name($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasName() => $_has(0);
  @$pb.TagNumber(1)
  void clearName() => clearField(1);

  @$pb.TagNumber(2)
  $core.String get description => $_getSZ(1);
  @$pb.TagNumber(2)
  set description($core.String v) { $_setString(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasDescription() => $_has(1);
  @$pb.TagNumber(2)
  void clearDescription() => clearField(2);

  @$pb.TagNumber(3)
  FeaturePipelineParameterValue get defaultValue => $_getN(2);
  @$pb.TagNumber(3)
  set defaultValue(FeaturePipelineParameterValue v) { setField(3, v); }
  @$pb.TagNumber(3)
  $core.bool hasDefaultValue() => $_has(2);
  @$pb.TagNumber(3)
  void clearDefaultValue() => clearField(3);
  @$pb.TagNumber(3)
  FeaturePipelineParameterValue ensureDefaultValue() => $_ensure(2);
}

class FeaturePipelineOrder extends $pb.GeneratedMessage {
  factory FeaturePipelineOrder({
    $core.String? type,
    $core.Iterable<FeaturePipelineParameterOrder>? parameters,
  }) {
    final $result = create();
    if (type != null) {
      $result.type = type;
    }
    if (parameters != null) {
      $result.parameters.addAll(parameters);
    }
    return $result;
  }
  FeaturePipelineOrder._() : super();
  factory FeaturePipelineOrder.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory FeaturePipelineOrder.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'FeaturePipelineOrder', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'type')
    ..pc<FeaturePipelineParameterOrder>(2, _omitFieldNames ? '' : 'parameters', $pb.PbFieldType.PM, subBuilder: FeaturePipelineParameterOrder.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  FeaturePipelineOrder clone() => FeaturePipelineOrder()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  FeaturePipelineOrder copyWith(void Function(FeaturePipelineOrder) updates) => super.copyWith((message) => updates(message as FeaturePipelineOrder)) as FeaturePipelineOrder;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static FeaturePipelineOrder create() => FeaturePipelineOrder._();
  FeaturePipelineOrder createEmptyInstance() => create();
  static $pb.PbList<FeaturePipelineOrder> createRepeated() => $pb.PbList<FeaturePipelineOrder>();
  @$core.pragma('dart2js:noInline')
  static FeaturePipelineOrder getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<FeaturePipelineOrder>(create);
  static FeaturePipelineOrder? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get type => $_getSZ(0);
  @$pb.TagNumber(1)
  set type($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasType() => $_has(0);
  @$pb.TagNumber(1)
  void clearType() => clearField(1);

  @$pb.TagNumber(2)
  $core.List<FeaturePipelineParameterOrder> get parameters => $_getList(1);
}

class FeaturePipelineParameterOrder extends $pb.GeneratedMessage {
  factory FeaturePipelineParameterOrder({
    $core.String? name,
    FeaturePipelineParameterValue? value,
  }) {
    final $result = create();
    if (name != null) {
      $result.name = name;
    }
    if (value != null) {
      $result.value = value;
    }
    return $result;
  }
  FeaturePipelineParameterOrder._() : super();
  factory FeaturePipelineParameterOrder.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory FeaturePipelineParameterOrder.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'FeaturePipelineParameterOrder', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'name')
    ..aOM<FeaturePipelineParameterValue>(2, _omitFieldNames ? '' : 'value', subBuilder: FeaturePipelineParameterValue.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  FeaturePipelineParameterOrder clone() => FeaturePipelineParameterOrder()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  FeaturePipelineParameterOrder copyWith(void Function(FeaturePipelineParameterOrder) updates) => super.copyWith((message) => updates(message as FeaturePipelineParameterOrder)) as FeaturePipelineParameterOrder;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static FeaturePipelineParameterOrder create() => FeaturePipelineParameterOrder._();
  FeaturePipelineParameterOrder createEmptyInstance() => create();
  static $pb.PbList<FeaturePipelineParameterOrder> createRepeated() => $pb.PbList<FeaturePipelineParameterOrder>();
  @$core.pragma('dart2js:noInline')
  static FeaturePipelineParameterOrder getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<FeaturePipelineParameterOrder>(create);
  static FeaturePipelineParameterOrder? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get name => $_getSZ(0);
  @$pb.TagNumber(1)
  set name($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasName() => $_has(0);
  @$pb.TagNumber(1)
  void clearName() => clearField(1);

  @$pb.TagNumber(2)
  FeaturePipelineParameterValue get value => $_getN(1);
  @$pb.TagNumber(2)
  set value(FeaturePipelineParameterValue v) { setField(2, v); }
  @$pb.TagNumber(2)
  $core.bool hasValue() => $_has(1);
  @$pb.TagNumber(2)
  void clearValue() => clearField(2);
  @$pb.TagNumber(2)
  FeaturePipelineParameterValue ensureValue() => $_ensure(1);
}

enum FeaturePipelineParameterValue_Value {
  stringValue, 
  longValue, 
  doubleValue, 
  boolValue, 
  listValue, 
  selectValue, 
  mapValue, 
  rangeValue, 
  notSet
}

class FeaturePipelineParameterValue extends $pb.GeneratedMessage {
  factory FeaturePipelineParameterValue({
    $core.String? stringValue,
    $fixnum.Int64? longValue,
    $core.double? doubleValue,
    $core.bool? boolValue,
    ListValue? listValue,
    SelectValue? selectValue,
    MapValue? mapValue,
    RangeValue? rangeValue,
  }) {
    final $result = create();
    if (stringValue != null) {
      $result.stringValue = stringValue;
    }
    if (longValue != null) {
      $result.longValue = longValue;
    }
    if (doubleValue != null) {
      $result.doubleValue = doubleValue;
    }
    if (boolValue != null) {
      $result.boolValue = boolValue;
    }
    if (listValue != null) {
      $result.listValue = listValue;
    }
    if (selectValue != null) {
      $result.selectValue = selectValue;
    }
    if (mapValue != null) {
      $result.mapValue = mapValue;
    }
    if (rangeValue != null) {
      $result.rangeValue = rangeValue;
    }
    return $result;
  }
  FeaturePipelineParameterValue._() : super();
  factory FeaturePipelineParameterValue.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory FeaturePipelineParameterValue.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static const $core.Map<$core.int, FeaturePipelineParameterValue_Value> _FeaturePipelineParameterValue_ValueByTag = {
    1 : FeaturePipelineParameterValue_Value.stringValue,
    2 : FeaturePipelineParameterValue_Value.longValue,
    3 : FeaturePipelineParameterValue_Value.doubleValue,
    4 : FeaturePipelineParameterValue_Value.boolValue,
    5 : FeaturePipelineParameterValue_Value.listValue,
    6 : FeaturePipelineParameterValue_Value.selectValue,
    7 : FeaturePipelineParameterValue_Value.mapValue,
    8 : FeaturePipelineParameterValue_Value.rangeValue,
    0 : FeaturePipelineParameterValue_Value.notSet
  };
  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'FeaturePipelineParameterValue', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..oo(0, [1, 2, 3, 4, 5, 6, 7, 8])
    ..aOS(1, _omitFieldNames ? '' : 'stringValue')
    ..aInt64(2, _omitFieldNames ? '' : 'longValue')
    ..a<$core.double>(3, _omitFieldNames ? '' : 'doubleValue', $pb.PbFieldType.OD)
    ..aOB(4, _omitFieldNames ? '' : 'boolValue')
    ..aOM<ListValue>(5, _omitFieldNames ? '' : 'listValue', subBuilder: ListValue.create)
    ..aOM<SelectValue>(6, _omitFieldNames ? '' : 'selectValue', subBuilder: SelectValue.create)
    ..aOM<MapValue>(7, _omitFieldNames ? '' : 'mapValue', subBuilder: MapValue.create)
    ..aOM<RangeValue>(8, _omitFieldNames ? '' : 'rangeValue', subBuilder: RangeValue.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  FeaturePipelineParameterValue clone() => FeaturePipelineParameterValue()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  FeaturePipelineParameterValue copyWith(void Function(FeaturePipelineParameterValue) updates) => super.copyWith((message) => updates(message as FeaturePipelineParameterValue)) as FeaturePipelineParameterValue;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static FeaturePipelineParameterValue create() => FeaturePipelineParameterValue._();
  FeaturePipelineParameterValue createEmptyInstance() => create();
  static $pb.PbList<FeaturePipelineParameterValue> createRepeated() => $pb.PbList<FeaturePipelineParameterValue>();
  @$core.pragma('dart2js:noInline')
  static FeaturePipelineParameterValue getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<FeaturePipelineParameterValue>(create);
  static FeaturePipelineParameterValue? _defaultInstance;

  FeaturePipelineParameterValue_Value whichValue() => _FeaturePipelineParameterValue_ValueByTag[$_whichOneof(0)]!;
  void clearValue() => clearField($_whichOneof(0));

  @$pb.TagNumber(1)
  $core.String get stringValue => $_getSZ(0);
  @$pb.TagNumber(1)
  set stringValue($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasStringValue() => $_has(0);
  @$pb.TagNumber(1)
  void clearStringValue() => clearField(1);

  @$pb.TagNumber(2)
  $fixnum.Int64 get longValue => $_getI64(1);
  @$pb.TagNumber(2)
  set longValue($fixnum.Int64 v) { $_setInt64(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasLongValue() => $_has(1);
  @$pb.TagNumber(2)
  void clearLongValue() => clearField(2);

  @$pb.TagNumber(3)
  $core.double get doubleValue => $_getN(2);
  @$pb.TagNumber(3)
  set doubleValue($core.double v) { $_setDouble(2, v); }
  @$pb.TagNumber(3)
  $core.bool hasDoubleValue() => $_has(2);
  @$pb.TagNumber(3)
  void clearDoubleValue() => clearField(3);

  @$pb.TagNumber(4)
  $core.bool get boolValue => $_getBF(3);
  @$pb.TagNumber(4)
  set boolValue($core.bool v) { $_setBool(3, v); }
  @$pb.TagNumber(4)
  $core.bool hasBoolValue() => $_has(3);
  @$pb.TagNumber(4)
  void clearBoolValue() => clearField(4);

  @$pb.TagNumber(5)
  ListValue get listValue => $_getN(4);
  @$pb.TagNumber(5)
  set listValue(ListValue v) { setField(5, v); }
  @$pb.TagNumber(5)
  $core.bool hasListValue() => $_has(4);
  @$pb.TagNumber(5)
  void clearListValue() => clearField(5);
  @$pb.TagNumber(5)
  ListValue ensureListValue() => $_ensure(4);

  @$pb.TagNumber(6)
  SelectValue get selectValue => $_getN(5);
  @$pb.TagNumber(6)
  set selectValue(SelectValue v) { setField(6, v); }
  @$pb.TagNumber(6)
  $core.bool hasSelectValue() => $_has(5);
  @$pb.TagNumber(6)
  void clearSelectValue() => clearField(6);
  @$pb.TagNumber(6)
  SelectValue ensureSelectValue() => $_ensure(5);

  @$pb.TagNumber(7)
  MapValue get mapValue => $_getN(6);
  @$pb.TagNumber(7)
  set mapValue(MapValue v) { setField(7, v); }
  @$pb.TagNumber(7)
  $core.bool hasMapValue() => $_has(6);
  @$pb.TagNumber(7)
  void clearMapValue() => clearField(7);
  @$pb.TagNumber(7)
  MapValue ensureMapValue() => $_ensure(6);

  @$pb.TagNumber(8)
  RangeValue get rangeValue => $_getN(7);
  @$pb.TagNumber(8)
  set rangeValue(RangeValue v) { setField(8, v); }
  @$pb.TagNumber(8)
  $core.bool hasRangeValue() => $_has(7);
  @$pb.TagNumber(8)
  void clearRangeValue() => clearField(8);
  @$pb.TagNumber(8)
  RangeValue ensureRangeValue() => $_ensure(7);
}

class ListValue extends $pb.GeneratedMessage {
  factory ListValue({
    $core.Iterable<$core.String>? values,
  }) {
    final $result = create();
    if (values != null) {
      $result.values.addAll(values);
    }
    return $result;
  }
  ListValue._() : super();
  factory ListValue.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory ListValue.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'ListValue', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..pPS(1, _omitFieldNames ? '' : 'values')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  ListValue clone() => ListValue()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  ListValue copyWith(void Function(ListValue) updates) => super.copyWith((message) => updates(message as ListValue)) as ListValue;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static ListValue create() => ListValue._();
  ListValue createEmptyInstance() => create();
  static $pb.PbList<ListValue> createRepeated() => $pb.PbList<ListValue>();
  @$core.pragma('dart2js:noInline')
  static ListValue getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<ListValue>(create);
  static ListValue? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<$core.String> get values => $_getList(0);
}

class SelectValue extends $pb.GeneratedMessage {
  factory SelectValue({
    $core.String? value,
    $core.Iterable<$core.String>? options,
  }) {
    final $result = create();
    if (value != null) {
      $result.value = value;
    }
    if (options != null) {
      $result.options.addAll(options);
    }
    return $result;
  }
  SelectValue._() : super();
  factory SelectValue.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory SelectValue.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'SelectValue', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'value')
    ..pPS(2, _omitFieldNames ? '' : 'options')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  SelectValue clone() => SelectValue()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  SelectValue copyWith(void Function(SelectValue) updates) => super.copyWith((message) => updates(message as SelectValue)) as SelectValue;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static SelectValue create() => SelectValue._();
  SelectValue createEmptyInstance() => create();
  static $pb.PbList<SelectValue> createRepeated() => $pb.PbList<SelectValue>();
  @$core.pragma('dart2js:noInline')
  static SelectValue getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<SelectValue>(create);
  static SelectValue? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get value => $_getSZ(0);
  @$pb.TagNumber(1)
  set value($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasValue() => $_has(0);
  @$pb.TagNumber(1)
  void clearValue() => clearField(1);

  @$pb.TagNumber(2)
  $core.List<$core.String> get options => $_getList(1);
}

class MapValue extends $pb.GeneratedMessage {
  factory MapValue({
    $core.Map<$core.String, $core.String>? values,
    SelectValue? selectableKeys,
    SelectValue? selectableValues,
  }) {
    final $result = create();
    if (values != null) {
      $result.values.addAll(values);
    }
    if (selectableKeys != null) {
      $result.selectableKeys = selectableKeys;
    }
    if (selectableValues != null) {
      $result.selectableValues = selectableValues;
    }
    return $result;
  }
  MapValue._() : super();
  factory MapValue.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory MapValue.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'MapValue', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..m<$core.String, $core.String>(1, _omitFieldNames ? '' : 'values', entryClassName: 'MapValue.ValuesEntry', keyFieldType: $pb.PbFieldType.OS, valueFieldType: $pb.PbFieldType.OS, packageName: const $pb.PackageName('feature'))
    ..aOM<SelectValue>(2, _omitFieldNames ? '' : 'selectableKeys', subBuilder: SelectValue.create)
    ..aOM<SelectValue>(3, _omitFieldNames ? '' : 'selectableValues', subBuilder: SelectValue.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  MapValue clone() => MapValue()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  MapValue copyWith(void Function(MapValue) updates) => super.copyWith((message) => updates(message as MapValue)) as MapValue;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static MapValue create() => MapValue._();
  MapValue createEmptyInstance() => create();
  static $pb.PbList<MapValue> createRepeated() => $pb.PbList<MapValue>();
  @$core.pragma('dart2js:noInline')
  static MapValue getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<MapValue>(create);
  static MapValue? _defaultInstance;

  @$pb.TagNumber(1)
  $core.Map<$core.String, $core.String> get values => $_getMap(0);

  @$pb.TagNumber(2)
  SelectValue get selectableKeys => $_getN(1);
  @$pb.TagNumber(2)
  set selectableKeys(SelectValue v) { setField(2, v); }
  @$pb.TagNumber(2)
  $core.bool hasSelectableKeys() => $_has(1);
  @$pb.TagNumber(2)
  void clearSelectableKeys() => clearField(2);
  @$pb.TagNumber(2)
  SelectValue ensureSelectableKeys() => $_ensure(1);

  @$pb.TagNumber(3)
  SelectValue get selectableValues => $_getN(2);
  @$pb.TagNumber(3)
  set selectableValues(SelectValue v) { setField(3, v); }
  @$pb.TagNumber(3)
  $core.bool hasSelectableValues() => $_has(2);
  @$pb.TagNumber(3)
  void clearSelectableValues() => clearField(3);
  @$pb.TagNumber(3)
  SelectValue ensureSelectableValues() => $_ensure(2);
}

class RangeValue extends $pb.GeneratedMessage {
  factory RangeValue({
    $core.double? value,
    $core.double? min,
    $core.double? max,
  }) {
    final $result = create();
    if (value != null) {
      $result.value = value;
    }
    if (min != null) {
      $result.min = min;
    }
    if (max != null) {
      $result.max = max;
    }
    return $result;
  }
  RangeValue._() : super();
  factory RangeValue.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory RangeValue.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'RangeValue', package: const $pb.PackageName(_omitMessageNames ? '' : 'feature'), createEmptyInstance: create)
    ..a<$core.double>(1, _omitFieldNames ? '' : 'value', $pb.PbFieldType.OD)
    ..a<$core.double>(2, _omitFieldNames ? '' : 'min', $pb.PbFieldType.OD)
    ..a<$core.double>(3, _omitFieldNames ? '' : 'max', $pb.PbFieldType.OD)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  RangeValue clone() => RangeValue()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  RangeValue copyWith(void Function(RangeValue) updates) => super.copyWith((message) => updates(message as RangeValue)) as RangeValue;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static RangeValue create() => RangeValue._();
  RangeValue createEmptyInstance() => create();
  static $pb.PbList<RangeValue> createRepeated() => $pb.PbList<RangeValue>();
  @$core.pragma('dart2js:noInline')
  static RangeValue getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<RangeValue>(create);
  static RangeValue? _defaultInstance;

  @$pb.TagNumber(1)
  $core.double get value => $_getN(0);
  @$pb.TagNumber(1)
  set value($core.double v) { $_setDouble(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasValue() => $_has(0);
  @$pb.TagNumber(1)
  void clearValue() => clearField(1);

  @$pb.TagNumber(2)
  $core.double get min => $_getN(1);
  @$pb.TagNumber(2)
  set min($core.double v) { $_setDouble(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasMin() => $_has(1);
  @$pb.TagNumber(2)
  void clearMin() => clearField(2);

  @$pb.TagNumber(3)
  $core.double get max => $_getN(2);
  @$pb.TagNumber(3)
  set max($core.double v) { $_setDouble(2, v); }
  @$pb.TagNumber(3)
  $core.bool hasMax() => $_has(2);
  @$pb.TagNumber(3)
  void clearMax() => clearField(3);
}


const _omitFieldNames = $core.bool.fromEnvironment('protobuf.omit_field_names');
const _omitMessageNames = $core.bool.fromEnvironment('protobuf.omit_message_names');

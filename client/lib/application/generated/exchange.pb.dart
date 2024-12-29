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
import 'dart:core' as $core;

// Package imports:
import 'package:protobuf/protobuf.dart' as $pb;

class Symbol extends $pb.GeneratedMessage {
  factory Symbol({
    $core.String? code,
    $core.String? name,
    ExchangePlace? place,
  }) {
    final $result = create();
    if (code != null) {
      $result.code = code;
    }
    if (name != null) {
      $result.name = name;
    }
    if (place != null) {
      $result.place = place;
    }
    return $result;
  }
  Symbol._() : super();
  factory Symbol.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory Symbol.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'Symbol', package: const $pb.PackageName(_omitMessageNames ? '' : 'exchange'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'code')
    ..aOS(2, _omitFieldNames ? '' : 'name')
    ..aOM<ExchangePlace>(3, _omitFieldNames ? '' : 'place', subBuilder: ExchangePlace.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  Symbol clone() => Symbol()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  Symbol copyWith(void Function(Symbol) updates) => super.copyWith((message) => updates(message as Symbol)) as Symbol;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static Symbol create() => Symbol._();
  Symbol createEmptyInstance() => create();
  static $pb.PbList<Symbol> createRepeated() => $pb.PbList<Symbol>();
  @$core.pragma('dart2js:noInline')
  static Symbol getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<Symbol>(create);
  static Symbol? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get code => $_getSZ(0);
  @$pb.TagNumber(1)
  set code($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasCode() => $_has(0);
  @$pb.TagNumber(1)
  void clearCode() => clearField(1);

  @$pb.TagNumber(2)
  $core.String get name => $_getSZ(1);
  @$pb.TagNumber(2)
  set name($core.String v) { $_setString(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasName() => $_has(1);
  @$pb.TagNumber(2)
  void clearName() => clearField(2);

  @$pb.TagNumber(3)
  ExchangePlace get place => $_getN(2);
  @$pb.TagNumber(3)
  set place(ExchangePlace v) { setField(3, v); }
  @$pb.TagNumber(3)
  $core.bool hasPlace() => $_has(2);
  @$pb.TagNumber(3)
  void clearPlace() => clearField(3);
  @$pb.TagNumber(3)
  ExchangePlace ensurePlace() => $_ensure(2);
}

class Symbols extends $pb.GeneratedMessage {
  factory Symbols({
    $core.Iterable<Symbol>? symbols,
  }) {
    final $result = create();
    if (symbols != null) {
      $result.symbols.addAll(symbols);
    }
    return $result;
  }
  Symbols._() : super();
  factory Symbols.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory Symbols.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'Symbols', package: const $pb.PackageName(_omitMessageNames ? '' : 'exchange'), createEmptyInstance: create)
    ..pc<Symbol>(1, _omitFieldNames ? '' : 'symbols', $pb.PbFieldType.PM, subBuilder: Symbol.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  Symbols clone() => Symbols()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  Symbols copyWith(void Function(Symbols) updates) => super.copyWith((message) => updates(message as Symbols)) as Symbols;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static Symbols create() => Symbols._();
  Symbols createEmptyInstance() => create();
  static $pb.PbList<Symbols> createRepeated() => $pb.PbList<Symbols>();
  @$core.pragma('dart2js:noInline')
  static Symbols getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<Symbols>(create);
  static Symbols? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<Symbol> get symbols => $_getList(0);
}

class ExchangePlace extends $pb.GeneratedMessage {
  factory ExchangePlace({
    $core.String? name,
    $core.bool? isBacktest,
  }) {
    final $result = create();
    if (name != null) {
      $result.name = name;
    }
    if (isBacktest != null) {
      $result.isBacktest = isBacktest;
    }
    return $result;
  }
  ExchangePlace._() : super();
  factory ExchangePlace.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory ExchangePlace.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'ExchangePlace', package: const $pb.PackageName(_omitMessageNames ? '' : 'exchange'), createEmptyInstance: create)
    ..aOS(1, _omitFieldNames ? '' : 'name')
    ..aOB(2, _omitFieldNames ? '' : 'isBacktest', protoName: 'isBacktest')
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  ExchangePlace clone() => ExchangePlace()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  ExchangePlace copyWith(void Function(ExchangePlace) updates) => super.copyWith((message) => updates(message as ExchangePlace)) as ExchangePlace;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static ExchangePlace create() => ExchangePlace._();
  ExchangePlace createEmptyInstance() => create();
  static $pb.PbList<ExchangePlace> createRepeated() => $pb.PbList<ExchangePlace>();
  @$core.pragma('dart2js:noInline')
  static ExchangePlace getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<ExchangePlace>(create);
  static ExchangePlace? _defaultInstance;

  @$pb.TagNumber(1)
  $core.String get name => $_getSZ(0);
  @$pb.TagNumber(1)
  set name($core.String v) { $_setString(0, v); }
  @$pb.TagNumber(1)
  $core.bool hasName() => $_has(0);
  @$pb.TagNumber(1)
  void clearName() => clearField(1);

  @$pb.TagNumber(2)
  $core.bool get isBacktest => $_getBF(1);
  @$pb.TagNumber(2)
  set isBacktest($core.bool v) { $_setBool(1, v); }
  @$pb.TagNumber(2)
  $core.bool hasIsBacktest() => $_has(1);
  @$pb.TagNumber(2)
  void clearIsBacktest() => clearField(2);
}

class ExchangePlaces extends $pb.GeneratedMessage {
  factory ExchangePlaces({
    $core.Iterable<ExchangePlace>? places,
  }) {
    final $result = create();
    if (places != null) {
      $result.places.addAll(places);
    }
    return $result;
  }
  ExchangePlaces._() : super();
  factory ExchangePlaces.fromBuffer($core.List<$core.int> i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromBuffer(i, r);
  factory ExchangePlaces.fromJson($core.String i, [$pb.ExtensionRegistry r = $pb.ExtensionRegistry.EMPTY]) => create()..mergeFromJson(i, r);

  static final $pb.BuilderInfo _i = $pb.BuilderInfo(_omitMessageNames ? '' : 'ExchangePlaces', package: const $pb.PackageName(_omitMessageNames ? '' : 'exchange'), createEmptyInstance: create)
    ..pc<ExchangePlace>(1, _omitFieldNames ? '' : 'places', $pb.PbFieldType.PM, subBuilder: ExchangePlace.create)
    ..hasRequiredFields = false
  ;

  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.deepCopy] instead. '
  'Will be removed in next major version')
  ExchangePlaces clone() => ExchangePlaces()..mergeFromMessage(this);
  @$core.Deprecated(
  'Using this can add significant overhead to your binary. '
  'Use [GeneratedMessageGenericExtensions.rebuild] instead. '
  'Will be removed in next major version')
  ExchangePlaces copyWith(void Function(ExchangePlaces) updates) => super.copyWith((message) => updates(message as ExchangePlaces)) as ExchangePlaces;

  $pb.BuilderInfo get info_ => _i;

  @$core.pragma('dart2js:noInline')
  static ExchangePlaces create() => ExchangePlaces._();
  ExchangePlaces createEmptyInstance() => create();
  static $pb.PbList<ExchangePlaces> createRepeated() => $pb.PbList<ExchangePlaces>();
  @$core.pragma('dart2js:noInline')
  static ExchangePlaces getDefault() => _defaultInstance ??= $pb.GeneratedMessage.$_defaultFor<ExchangePlaces>(create);
  static ExchangePlaces? _defaultInstance;

  @$pb.TagNumber(1)
  $core.List<ExchangePlace> get places => $_getList(0);
}


const _omitFieldNames = $core.bool.fromEnvironment('protobuf.omit_field_names');
const _omitMessageNames = $core.bool.fromEnvironment('protobuf.omit_message_names');

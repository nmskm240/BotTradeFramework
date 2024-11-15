// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'bot_setting.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$BotSetting {
  String get place => throw _privateConstructorUsedError;
  String get symbol => throw _privateConstructorUsedError;
  List<FeaturePipelineSetting> get featurePipelines =>
      throw _privateConstructorUsedError;

  /// Create a copy of BotSetting
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $BotSettingCopyWith<BotSetting> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $BotSettingCopyWith<$Res> {
  factory $BotSettingCopyWith(
          BotSetting value, $Res Function(BotSetting) then) =
      _$BotSettingCopyWithImpl<$Res, BotSetting>;
  @useResult
  $Res call(
      {String place,
      String symbol,
      List<FeaturePipelineSetting> featurePipelines});
}

/// @nodoc
class _$BotSettingCopyWithImpl<$Res, $Val extends BotSetting>
    implements $BotSettingCopyWith<$Res> {
  _$BotSettingCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of BotSetting
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? place = null,
    Object? symbol = null,
    Object? featurePipelines = null,
  }) {
    return _then(_value.copyWith(
      place: null == place
          ? _value.place
          : place // ignore: cast_nullable_to_non_nullable
              as String,
      symbol: null == symbol
          ? _value.symbol
          : symbol // ignore: cast_nullable_to_non_nullable
              as String,
      featurePipelines: null == featurePipelines
          ? _value.featurePipelines
          : featurePipelines // ignore: cast_nullable_to_non_nullable
              as List<FeaturePipelineSetting>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$BotSettingImplCopyWith<$Res>
    implements $BotSettingCopyWith<$Res> {
  factory _$$BotSettingImplCopyWith(
          _$BotSettingImpl value, $Res Function(_$BotSettingImpl) then) =
      __$$BotSettingImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String place,
      String symbol,
      List<FeaturePipelineSetting> featurePipelines});
}

/// @nodoc
class __$$BotSettingImplCopyWithImpl<$Res>
    extends _$BotSettingCopyWithImpl<$Res, _$BotSettingImpl>
    implements _$$BotSettingImplCopyWith<$Res> {
  __$$BotSettingImplCopyWithImpl(
      _$BotSettingImpl _value, $Res Function(_$BotSettingImpl) _then)
      : super(_value, _then);

  /// Create a copy of BotSetting
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? place = null,
    Object? symbol = null,
    Object? featurePipelines = null,
  }) {
    return _then(_$BotSettingImpl(
      place: null == place
          ? _value.place
          : place // ignore: cast_nullable_to_non_nullable
              as String,
      symbol: null == symbol
          ? _value.symbol
          : symbol // ignore: cast_nullable_to_non_nullable
              as String,
      featurePipelines: null == featurePipelines
          ? _value._featurePipelines
          : featurePipelines // ignore: cast_nullable_to_non_nullable
              as List<FeaturePipelineSetting>,
    ));
  }
}

/// @nodoc

class _$BotSettingImpl implements _BotSetting {
  const _$BotSettingImpl(
      {this.place = "",
      this.symbol = "",
      final List<FeaturePipelineSetting> featurePipelines = const []})
      : _featurePipelines = featurePipelines;

  @override
  @JsonKey()
  final String place;
  @override
  @JsonKey()
  final String symbol;
  final List<FeaturePipelineSetting> _featurePipelines;
  @override
  @JsonKey()
  List<FeaturePipelineSetting> get featurePipelines {
    if (_featurePipelines is EqualUnmodifiableListView)
      return _featurePipelines;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_featurePipelines);
  }

  @override
  String toString() {
    return 'BotSetting(place: $place, symbol: $symbol, featurePipelines: $featurePipelines)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$BotSettingImpl &&
            (identical(other.place, place) || other.place == place) &&
            (identical(other.symbol, symbol) || other.symbol == symbol) &&
            const DeepCollectionEquality()
                .equals(other._featurePipelines, _featurePipelines));
  }

  @override
  int get hashCode => Object.hash(runtimeType, place, symbol,
      const DeepCollectionEquality().hash(_featurePipelines));

  /// Create a copy of BotSetting
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$BotSettingImplCopyWith<_$BotSettingImpl> get copyWith =>
      __$$BotSettingImplCopyWithImpl<_$BotSettingImpl>(this, _$identity);
}

abstract class _BotSetting implements BotSetting {
  const factory _BotSetting(
      {final String place,
      final String symbol,
      final List<FeaturePipelineSetting> featurePipelines}) = _$BotSettingImpl;

  @override
  String get place;
  @override
  String get symbol;
  @override
  List<FeaturePipelineSetting> get featurePipelines;

  /// Create a copy of BotSetting
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$BotSettingImplCopyWith<_$BotSettingImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

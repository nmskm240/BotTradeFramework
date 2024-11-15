// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'feature_pipeline_setting.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$FeaturePipelineSetting {
  String get method => throw _privateConstructorUsedError;
  List<String> get targetColumns => throw _privateConstructorUsedError;
  List<String> get values => throw _privateConstructorUsedError;
  int get bufferSize => throw _privateConstructorUsedError;

  /// Create a copy of FeaturePipelineSetting
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $FeaturePipelineSettingCopyWith<FeaturePipelineSetting> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $FeaturePipelineSettingCopyWith<$Res> {
  factory $FeaturePipelineSettingCopyWith(FeaturePipelineSetting value,
          $Res Function(FeaturePipelineSetting) then) =
      _$FeaturePipelineSettingCopyWithImpl<$Res, FeaturePipelineSetting>;
  @useResult
  $Res call(
      {String method,
      List<String> targetColumns,
      List<String> values,
      int bufferSize});
}

/// @nodoc
class _$FeaturePipelineSettingCopyWithImpl<$Res,
        $Val extends FeaturePipelineSetting>
    implements $FeaturePipelineSettingCopyWith<$Res> {
  _$FeaturePipelineSettingCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of FeaturePipelineSetting
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? method = null,
    Object? targetColumns = null,
    Object? values = null,
    Object? bufferSize = null,
  }) {
    return _then(_value.copyWith(
      method: null == method
          ? _value.method
          : method // ignore: cast_nullable_to_non_nullable
              as String,
      targetColumns: null == targetColumns
          ? _value.targetColumns
          : targetColumns // ignore: cast_nullable_to_non_nullable
              as List<String>,
      values: null == values
          ? _value.values
          : values // ignore: cast_nullable_to_non_nullable
              as List<String>,
      bufferSize: null == bufferSize
          ? _value.bufferSize
          : bufferSize // ignore: cast_nullable_to_non_nullable
              as int,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$$FeaturePiplineSettingImplCopyWith<$Res>
    implements $FeaturePipelineSettingCopyWith<$Res> {
  factory _$$$FeaturePiplineSettingImplCopyWith(
          _$$FeaturePiplineSettingImpl value,
          $Res Function(_$$FeaturePiplineSettingImpl) then) =
      __$$$FeaturePiplineSettingImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String method,
      List<String> targetColumns,
      List<String> values,
      int bufferSize});
}

/// @nodoc
class __$$$FeaturePiplineSettingImplCopyWithImpl<$Res>
    extends _$FeaturePipelineSettingCopyWithImpl<$Res,
        _$$FeaturePiplineSettingImpl>
    implements _$$$FeaturePiplineSettingImplCopyWith<$Res> {
  __$$$FeaturePiplineSettingImplCopyWithImpl(
      _$$FeaturePiplineSettingImpl _value,
      $Res Function(_$$FeaturePiplineSettingImpl) _then)
      : super(_value, _then);

  /// Create a copy of FeaturePipelineSetting
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? method = null,
    Object? targetColumns = null,
    Object? values = null,
    Object? bufferSize = null,
  }) {
    return _then(_$$FeaturePiplineSettingImpl(
      method: null == method
          ? _value.method
          : method // ignore: cast_nullable_to_non_nullable
              as String,
      targetColumns: null == targetColumns
          ? _value._targetColumns
          : targetColumns // ignore: cast_nullable_to_non_nullable
              as List<String>,
      values: null == values
          ? _value._values
          : values // ignore: cast_nullable_to_non_nullable
              as List<String>,
      bufferSize: null == bufferSize
          ? _value.bufferSize
          : bufferSize // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc

class _$$FeaturePiplineSettingImpl implements $FeaturePiplineSetting {
  const _$$FeaturePiplineSettingImpl(
      {this.method = "",
      final List<String> targetColumns = const [],
      final List<String> values = const [],
      this.bufferSize = 0})
      : _targetColumns = targetColumns,
        _values = values;

  @override
  @JsonKey()
  final String method;
  final List<String> _targetColumns;
  @override
  @JsonKey()
  List<String> get targetColumns {
    if (_targetColumns is EqualUnmodifiableListView) return _targetColumns;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_targetColumns);
  }

  final List<String> _values;
  @override
  @JsonKey()
  List<String> get values {
    if (_values is EqualUnmodifiableListView) return _values;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_values);
  }

  @override
  @JsonKey()
  final int bufferSize;

  @override
  String toString() {
    return 'FeaturePipelineSetting(method: $method, targetColumns: $targetColumns, values: $values, bufferSize: $bufferSize)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$$FeaturePiplineSettingImpl &&
            (identical(other.method, method) || other.method == method) &&
            const DeepCollectionEquality()
                .equals(other._targetColumns, _targetColumns) &&
            const DeepCollectionEquality().equals(other._values, _values) &&
            (identical(other.bufferSize, bufferSize) ||
                other.bufferSize == bufferSize));
  }

  @override
  int get hashCode => Object.hash(
      runtimeType,
      method,
      const DeepCollectionEquality().hash(_targetColumns),
      const DeepCollectionEquality().hash(_values),
      bufferSize);

  /// Create a copy of FeaturePipelineSetting
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$$FeaturePiplineSettingImplCopyWith<_$$FeaturePiplineSettingImpl>
      get copyWith => __$$$FeaturePiplineSettingImplCopyWithImpl<
          _$$FeaturePiplineSettingImpl>(this, _$identity);
}

abstract class $FeaturePiplineSetting implements FeaturePipelineSetting {
  const factory $FeaturePiplineSetting(
      {final String method,
      final List<String> targetColumns,
      final List<String> values,
      final int bufferSize}) = _$$FeaturePiplineSettingImpl;

  @override
  String get method;
  @override
  List<String> get targetColumns;
  @override
  List<String> get values;
  @override
  int get bufferSize;

  /// Create a copy of FeaturePipelineSetting
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$$FeaturePiplineSettingImplCopyWith<_$$FeaturePiplineSettingImpl>
      get copyWith => throw _privateConstructorUsedError;
}

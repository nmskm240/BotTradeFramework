// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'feature_edit_page_state.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$FeatureEditPageState {
  GlobalKey<FormBuilderState> get formKey => throw _privateConstructorUsedError;
  FeaturePipelineSetting get setting => throw _privateConstructorUsedError;

  /// Create a copy of FeatureEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $FeatureEditPageStateCopyWith<FeatureEditPageState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $FeatureEditPageStateCopyWith<$Res> {
  factory $FeatureEditPageStateCopyWith(FeatureEditPageState value,
          $Res Function(FeatureEditPageState) then) =
      _$FeatureEditPageStateCopyWithImpl<$Res, FeatureEditPageState>;
  @useResult
  $Res call(
      {GlobalKey<FormBuilderState> formKey, FeaturePipelineSetting setting});

  $FeaturePipelineSettingCopyWith<$Res> get setting;
}

/// @nodoc
class _$FeatureEditPageStateCopyWithImpl<$Res,
        $Val extends FeatureEditPageState>
    implements $FeatureEditPageStateCopyWith<$Res> {
  _$FeatureEditPageStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of FeatureEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? formKey = null,
    Object? setting = null,
  }) {
    return _then(_value.copyWith(
      formKey: null == formKey
          ? _value.formKey
          : formKey // ignore: cast_nullable_to_non_nullable
              as GlobalKey<FormBuilderState>,
      setting: null == setting
          ? _value.setting
          : setting // ignore: cast_nullable_to_non_nullable
              as FeaturePipelineSetting,
    ) as $Val);
  }

  /// Create a copy of FeatureEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $FeaturePipelineSettingCopyWith<$Res> get setting {
    return $FeaturePipelineSettingCopyWith<$Res>(_value.setting, (value) {
      return _then(_value.copyWith(setting: value) as $Val);
    });
  }
}

/// @nodoc
abstract class _$$FeatureEditPageStateImplCopyWith<$Res>
    implements $FeatureEditPageStateCopyWith<$Res> {
  factory _$$FeatureEditPageStateImplCopyWith(_$FeatureEditPageStateImpl value,
          $Res Function(_$FeatureEditPageStateImpl) then) =
      __$$FeatureEditPageStateImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {GlobalKey<FormBuilderState> formKey, FeaturePipelineSetting setting});

  @override
  $FeaturePipelineSettingCopyWith<$Res> get setting;
}

/// @nodoc
class __$$FeatureEditPageStateImplCopyWithImpl<$Res>
    extends _$FeatureEditPageStateCopyWithImpl<$Res, _$FeatureEditPageStateImpl>
    implements _$$FeatureEditPageStateImplCopyWith<$Res> {
  __$$FeatureEditPageStateImplCopyWithImpl(_$FeatureEditPageStateImpl _value,
      $Res Function(_$FeatureEditPageStateImpl) _then)
      : super(_value, _then);

  /// Create a copy of FeatureEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? formKey = null,
    Object? setting = null,
  }) {
    return _then(_$FeatureEditPageStateImpl(
      formKey: null == formKey
          ? _value.formKey
          : formKey // ignore: cast_nullable_to_non_nullable
              as GlobalKey<FormBuilderState>,
      setting: null == setting
          ? _value.setting
          : setting // ignore: cast_nullable_to_non_nullable
              as FeaturePipelineSetting,
    ));
  }
}

/// @nodoc

class _$FeatureEditPageStateImpl implements _FeatureEditPageState {
  const _$FeatureEditPageStateImpl(
      {required this.formKey, required this.setting});

  @override
  final GlobalKey<FormBuilderState> formKey;
  @override
  final FeaturePipelineSetting setting;

  @override
  String toString() {
    return 'FeatureEditPageState(formKey: $formKey, setting: $setting)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$FeatureEditPageStateImpl &&
            (identical(other.formKey, formKey) || other.formKey == formKey) &&
            (identical(other.setting, setting) || other.setting == setting));
  }

  @override
  int get hashCode => Object.hash(runtimeType, formKey, setting);

  /// Create a copy of FeatureEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$FeatureEditPageStateImplCopyWith<_$FeatureEditPageStateImpl>
      get copyWith =>
          __$$FeatureEditPageStateImplCopyWithImpl<_$FeatureEditPageStateImpl>(
              this, _$identity);
}

abstract class _FeatureEditPageState implements FeatureEditPageState {
  const factory _FeatureEditPageState(
          {required final GlobalKey<FormBuilderState> formKey,
          required final FeaturePipelineSetting setting}) =
      _$FeatureEditPageStateImpl;

  @override
  GlobalKey<FormBuilderState> get formKey;
  @override
  FeaturePipelineSetting get setting;

  /// Create a copy of FeatureEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$FeatureEditPageStateImplCopyWith<_$FeatureEditPageStateImpl>
      get copyWith => throw _privateConstructorUsedError;
}

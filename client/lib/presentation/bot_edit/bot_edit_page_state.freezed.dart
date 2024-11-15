// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'bot_edit_page_state.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$BotEditPageState {
  GlobalKey<FormBuilderState> get formKey => throw _privateConstructorUsedError;
  BotSetting get setting => throw _privateConstructorUsedError;

  /// Create a copy of BotEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $BotEditPageStateCopyWith<BotEditPageState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $BotEditPageStateCopyWith<$Res> {
  factory $BotEditPageStateCopyWith(
          BotEditPageState value, $Res Function(BotEditPageState) then) =
      _$BotEditPageStateCopyWithImpl<$Res, BotEditPageState>;
  @useResult
  $Res call({GlobalKey<FormBuilderState> formKey, BotSetting setting});

  $BotSettingCopyWith<$Res> get setting;
}

/// @nodoc
class _$BotEditPageStateCopyWithImpl<$Res, $Val extends BotEditPageState>
    implements $BotEditPageStateCopyWith<$Res> {
  _$BotEditPageStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of BotEditPageState
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
              as BotSetting,
    ) as $Val);
  }

  /// Create a copy of BotEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $BotSettingCopyWith<$Res> get setting {
    return $BotSettingCopyWith<$Res>(_value.setting, (value) {
      return _then(_value.copyWith(setting: value) as $Val);
    });
  }
}

/// @nodoc
abstract class _$$BotEditPageStateImplCopyWith<$Res>
    implements $BotEditPageStateCopyWith<$Res> {
  factory _$$BotEditPageStateImplCopyWith(_$BotEditPageStateImpl value,
          $Res Function(_$BotEditPageStateImpl) then) =
      __$$BotEditPageStateImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({GlobalKey<FormBuilderState> formKey, BotSetting setting});

  @override
  $BotSettingCopyWith<$Res> get setting;
}

/// @nodoc
class __$$BotEditPageStateImplCopyWithImpl<$Res>
    extends _$BotEditPageStateCopyWithImpl<$Res, _$BotEditPageStateImpl>
    implements _$$BotEditPageStateImplCopyWith<$Res> {
  __$$BotEditPageStateImplCopyWithImpl(_$BotEditPageStateImpl _value,
      $Res Function(_$BotEditPageStateImpl) _then)
      : super(_value, _then);

  /// Create a copy of BotEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? formKey = null,
    Object? setting = null,
  }) {
    return _then(_$BotEditPageStateImpl(
      formKey: null == formKey
          ? _value.formKey
          : formKey // ignore: cast_nullable_to_non_nullable
              as GlobalKey<FormBuilderState>,
      setting: null == setting
          ? _value.setting
          : setting // ignore: cast_nullable_to_non_nullable
              as BotSetting,
    ));
  }
}

/// @nodoc

class _$BotEditPageStateImpl implements _BotEditPageState {
  const _$BotEditPageStateImpl({required this.formKey, required this.setting});

  @override
  final GlobalKey<FormBuilderState> formKey;
  @override
  final BotSetting setting;

  @override
  String toString() {
    return 'BotEditPageState(formKey: $formKey, setting: $setting)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$BotEditPageStateImpl &&
            (identical(other.formKey, formKey) || other.formKey == formKey) &&
            (identical(other.setting, setting) || other.setting == setting));
  }

  @override
  int get hashCode => Object.hash(runtimeType, formKey, setting);

  /// Create a copy of BotEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$BotEditPageStateImplCopyWith<_$BotEditPageStateImpl> get copyWith =>
      __$$BotEditPageStateImplCopyWithImpl<_$BotEditPageStateImpl>(
          this, _$identity);
}

abstract class _BotEditPageState implements BotEditPageState {
  const factory _BotEditPageState(
      {required final GlobalKey<FormBuilderState> formKey,
      required final BotSetting setting}) = _$BotEditPageStateImpl;

  @override
  GlobalKey<FormBuilderState> get formKey;
  @override
  BotSetting get setting;

  /// Create a copy of BotEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$BotEditPageStateImplCopyWith<_$BotEditPageStateImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

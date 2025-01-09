// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'bot_edit_form.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$BotEditFormState {
  GlobalKey<FormBuilderState> get formKey => throw _privateConstructorUsedError;
  List<ExchangePlace> get selectablePlaces =>
      throw _privateConstructorUsedError;
  List<Symbol> get selectableSymbols => throw _privateConstructorUsedError;

  /// Create a copy of BotEditFormState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $BotEditFormStateCopyWith<BotEditFormState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $BotEditFormStateCopyWith<$Res> {
  factory $BotEditFormStateCopyWith(
          BotEditFormState value, $Res Function(BotEditFormState) then) =
      _$BotEditFormStateCopyWithImpl<$Res, BotEditFormState>;
  @useResult
  $Res call(
      {GlobalKey<FormBuilderState> formKey,
      List<ExchangePlace> selectablePlaces,
      List<Symbol> selectableSymbols});
}

/// @nodoc
class _$BotEditFormStateCopyWithImpl<$Res, $Val extends BotEditFormState>
    implements $BotEditFormStateCopyWith<$Res> {
  _$BotEditFormStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of BotEditFormState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? formKey = null,
    Object? selectablePlaces = null,
    Object? selectableSymbols = null,
  }) {
    return _then(_value.copyWith(
      formKey: null == formKey
          ? _value.formKey
          : formKey // ignore: cast_nullable_to_non_nullable
              as GlobalKey<FormBuilderState>,
      selectablePlaces: null == selectablePlaces
          ? _value.selectablePlaces
          : selectablePlaces // ignore: cast_nullable_to_non_nullable
              as List<ExchangePlace>,
      selectableSymbols: null == selectableSymbols
          ? _value.selectableSymbols
          : selectableSymbols // ignore: cast_nullable_to_non_nullable
              as List<Symbol>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$BotEditFormStateImplCopyWith<$Res>
    implements $BotEditFormStateCopyWith<$Res> {
  factory _$$BotEditFormStateImplCopyWith(_$BotEditFormStateImpl value,
          $Res Function(_$BotEditFormStateImpl) then) =
      __$$BotEditFormStateImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {GlobalKey<FormBuilderState> formKey,
      List<ExchangePlace> selectablePlaces,
      List<Symbol> selectableSymbols});
}

/// @nodoc
class __$$BotEditFormStateImplCopyWithImpl<$Res>
    extends _$BotEditFormStateCopyWithImpl<$Res, _$BotEditFormStateImpl>
    implements _$$BotEditFormStateImplCopyWith<$Res> {
  __$$BotEditFormStateImplCopyWithImpl(_$BotEditFormStateImpl _value,
      $Res Function(_$BotEditFormStateImpl) _then)
      : super(_value, _then);

  /// Create a copy of BotEditFormState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? formKey = null,
    Object? selectablePlaces = null,
    Object? selectableSymbols = null,
  }) {
    return _then(_$BotEditFormStateImpl(
      formKey: null == formKey
          ? _value.formKey
          : formKey // ignore: cast_nullable_to_non_nullable
              as GlobalKey<FormBuilderState>,
      selectablePlaces: null == selectablePlaces
          ? _value._selectablePlaces
          : selectablePlaces // ignore: cast_nullable_to_non_nullable
              as List<ExchangePlace>,
      selectableSymbols: null == selectableSymbols
          ? _value._selectableSymbols
          : selectableSymbols // ignore: cast_nullable_to_non_nullable
              as List<Symbol>,
    ));
  }
}

/// @nodoc

class _$BotEditFormStateImpl implements _BotEditFormState {
  const _$BotEditFormStateImpl(
      {required this.formKey,
      final List<ExchangePlace> selectablePlaces = const [],
      final List<Symbol> selectableSymbols = const []})
      : _selectablePlaces = selectablePlaces,
        _selectableSymbols = selectableSymbols;

  @override
  final GlobalKey<FormBuilderState> formKey;
  final List<ExchangePlace> _selectablePlaces;
  @override
  @JsonKey()
  List<ExchangePlace> get selectablePlaces {
    if (_selectablePlaces is EqualUnmodifiableListView)
      return _selectablePlaces;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_selectablePlaces);
  }

  final List<Symbol> _selectableSymbols;
  @override
  @JsonKey()
  List<Symbol> get selectableSymbols {
    if (_selectableSymbols is EqualUnmodifiableListView)
      return _selectableSymbols;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_selectableSymbols);
  }

  @override
  String toString() {
    return 'BotEditFormState(formKey: $formKey, selectablePlaces: $selectablePlaces, selectableSymbols: $selectableSymbols)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$BotEditFormStateImpl &&
            (identical(other.formKey, formKey) || other.formKey == formKey) &&
            const DeepCollectionEquality()
                .equals(other._selectablePlaces, _selectablePlaces) &&
            const DeepCollectionEquality()
                .equals(other._selectableSymbols, _selectableSymbols));
  }

  @override
  int get hashCode => Object.hash(
      runtimeType,
      formKey,
      const DeepCollectionEquality().hash(_selectablePlaces),
      const DeepCollectionEquality().hash(_selectableSymbols));

  /// Create a copy of BotEditFormState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$BotEditFormStateImplCopyWith<_$BotEditFormStateImpl> get copyWith =>
      __$$BotEditFormStateImplCopyWithImpl<_$BotEditFormStateImpl>(
          this, _$identity);
}

abstract class _BotEditFormState implements BotEditFormState {
  const factory _BotEditFormState(
      {required final GlobalKey<FormBuilderState> formKey,
      final List<ExchangePlace> selectablePlaces,
      final List<Symbol> selectableSymbols}) = _$BotEditFormStateImpl;

  @override
  GlobalKey<FormBuilderState> get formKey;
  @override
  List<ExchangePlace> get selectablePlaces;
  @override
  List<Symbol> get selectableSymbols;

  /// Create a copy of BotEditFormState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$BotEditFormStateImplCopyWith<_$BotEditFormStateImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

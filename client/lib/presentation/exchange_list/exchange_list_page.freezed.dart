// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'exchange_list_page.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$ExchangeListPageState {
  List<ExchangePlace> get exchanges => throw _privateConstructorUsedError;

  /// Create a copy of ExchangeListPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $ExchangeListPageStateCopyWith<ExchangeListPageState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ExchangeListPageStateCopyWith<$Res> {
  factory $ExchangeListPageStateCopyWith(ExchangeListPageState value,
          $Res Function(ExchangeListPageState) then) =
      _$ExchangeListPageStateCopyWithImpl<$Res, ExchangeListPageState>;
  @useResult
  $Res call({List<ExchangePlace> exchanges});
}

/// @nodoc
class _$ExchangeListPageStateCopyWithImpl<$Res,
        $Val extends ExchangeListPageState>
    implements $ExchangeListPageStateCopyWith<$Res> {
  _$ExchangeListPageStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of ExchangeListPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? exchanges = null,
  }) {
    return _then(_value.copyWith(
      exchanges: null == exchanges
          ? _value.exchanges
          : exchanges // ignore: cast_nullable_to_non_nullable
              as List<ExchangePlace>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$ExchangeListPageStateImplCopyWith<$Res>
    implements $ExchangeListPageStateCopyWith<$Res> {
  factory _$$ExchangeListPageStateImplCopyWith(
          _$ExchangeListPageStateImpl value,
          $Res Function(_$ExchangeListPageStateImpl) then) =
      __$$ExchangeListPageStateImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({List<ExchangePlace> exchanges});
}

/// @nodoc
class __$$ExchangeListPageStateImplCopyWithImpl<$Res>
    extends _$ExchangeListPageStateCopyWithImpl<$Res,
        _$ExchangeListPageStateImpl>
    implements _$$ExchangeListPageStateImplCopyWith<$Res> {
  __$$ExchangeListPageStateImplCopyWithImpl(_$ExchangeListPageStateImpl _value,
      $Res Function(_$ExchangeListPageStateImpl) _then)
      : super(_value, _then);

  /// Create a copy of ExchangeListPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? exchanges = null,
  }) {
    return _then(_$ExchangeListPageStateImpl(
      exchanges: null == exchanges
          ? _value._exchanges
          : exchanges // ignore: cast_nullable_to_non_nullable
              as List<ExchangePlace>,
    ));
  }
}

/// @nodoc

class _$ExchangeListPageStateImpl implements _ExchangeListPageState {
  const _$ExchangeListPageStateImpl(
      {final List<ExchangePlace> exchanges = const []})
      : _exchanges = exchanges;

  final List<ExchangePlace> _exchanges;
  @override
  @JsonKey()
  List<ExchangePlace> get exchanges {
    if (_exchanges is EqualUnmodifiableListView) return _exchanges;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_exchanges);
  }

  @override
  String toString() {
    return 'ExchangeListPageState(exchanges: $exchanges)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$ExchangeListPageStateImpl &&
            const DeepCollectionEquality()
                .equals(other._exchanges, _exchanges));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(_exchanges));

  /// Create a copy of ExchangeListPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$ExchangeListPageStateImplCopyWith<_$ExchangeListPageStateImpl>
      get copyWith => __$$ExchangeListPageStateImplCopyWithImpl<
          _$ExchangeListPageStateImpl>(this, _$identity);
}

abstract class _ExchangeListPageState implements ExchangeListPageState {
  const factory _ExchangeListPageState({final List<ExchangePlace> exchanges}) =
      _$ExchangeListPageStateImpl;

  @override
  List<ExchangePlace> get exchanges;

  /// Create a copy of ExchangeListPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$ExchangeListPageStateImplCopyWith<_$ExchangeListPageStateImpl>
      get copyWith => throw _privateConstructorUsedError;
}

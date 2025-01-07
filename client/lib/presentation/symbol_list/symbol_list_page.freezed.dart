// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'symbol_list_page.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$SymbolListPageState {
  List<Symbol> get symbols => throw _privateConstructorUsedError;

  /// Create a copy of SymbolListPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $SymbolListPageStateCopyWith<SymbolListPageState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $SymbolListPageStateCopyWith<$Res> {
  factory $SymbolListPageStateCopyWith(
          SymbolListPageState value, $Res Function(SymbolListPageState) then) =
      _$SymbolListPageStateCopyWithImpl<$Res, SymbolListPageState>;
  @useResult
  $Res call({List<Symbol> symbols});
}

/// @nodoc
class _$SymbolListPageStateCopyWithImpl<$Res, $Val extends SymbolListPageState>
    implements $SymbolListPageStateCopyWith<$Res> {
  _$SymbolListPageStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of SymbolListPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? symbols = null,
  }) {
    return _then(_value.copyWith(
      symbols: null == symbols
          ? _value.symbols
          : symbols // ignore: cast_nullable_to_non_nullable
              as List<Symbol>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$SymbolListPageStateImplCopyWith<$Res>
    implements $SymbolListPageStateCopyWith<$Res> {
  factory _$$SymbolListPageStateImplCopyWith(_$SymbolListPageStateImpl value,
          $Res Function(_$SymbolListPageStateImpl) then) =
      __$$SymbolListPageStateImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({List<Symbol> symbols});
}

/// @nodoc
class __$$SymbolListPageStateImplCopyWithImpl<$Res>
    extends _$SymbolListPageStateCopyWithImpl<$Res, _$SymbolListPageStateImpl>
    implements _$$SymbolListPageStateImplCopyWith<$Res> {
  __$$SymbolListPageStateImplCopyWithImpl(_$SymbolListPageStateImpl _value,
      $Res Function(_$SymbolListPageStateImpl) _then)
      : super(_value, _then);

  /// Create a copy of SymbolListPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? symbols = null,
  }) {
    return _then(_$SymbolListPageStateImpl(
      symbols: null == symbols
          ? _value._symbols
          : symbols // ignore: cast_nullable_to_non_nullable
              as List<Symbol>,
    ));
  }
}

/// @nodoc

class _$SymbolListPageStateImpl implements _SymbolListPageState {
  const _$SymbolListPageStateImpl({final List<Symbol> symbols = const []})
      : _symbols = symbols;

  final List<Symbol> _symbols;
  @override
  @JsonKey()
  List<Symbol> get symbols {
    if (_symbols is EqualUnmodifiableListView) return _symbols;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_symbols);
  }

  @override
  String toString() {
    return 'SymbolListPageState(symbols: $symbols)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$SymbolListPageStateImpl &&
            const DeepCollectionEquality().equals(other._symbols, _symbols));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(_symbols));

  /// Create a copy of SymbolListPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$SymbolListPageStateImplCopyWith<_$SymbolListPageStateImpl> get copyWith =>
      __$$SymbolListPageStateImplCopyWithImpl<_$SymbolListPageStateImpl>(
          this, _$identity);
}

abstract class _SymbolListPageState implements SymbolListPageState {
  const factory _SymbolListPageState({final List<Symbol> symbols}) =
      _$SymbolListPageStateImpl;

  @override
  List<Symbol> get symbols;

  /// Create a copy of SymbolListPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$SymbolListPageStateImplCopyWith<_$SymbolListPageStateImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

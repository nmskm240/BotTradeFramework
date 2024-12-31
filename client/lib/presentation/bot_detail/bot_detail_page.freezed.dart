// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'bot_detail_page.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$BotDetailPageState {
  List<BotPerformance> get activities => throw _privateConstructorUsedError;

  /// Create a copy of BotDetailPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $BotDetailPageStateCopyWith<BotDetailPageState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $BotDetailPageStateCopyWith<$Res> {
  factory $BotDetailPageStateCopyWith(
          BotDetailPageState value, $Res Function(BotDetailPageState) then) =
      _$BotDetailPageStateCopyWithImpl<$Res, BotDetailPageState>;
  @useResult
  $Res call({List<BotPerformance> activities});
}

/// @nodoc
class _$BotDetailPageStateCopyWithImpl<$Res, $Val extends BotDetailPageState>
    implements $BotDetailPageStateCopyWith<$Res> {
  _$BotDetailPageStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of BotDetailPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? activities = null,
  }) {
    return _then(_value.copyWith(
      activities: null == activities
          ? _value.activities
          : activities // ignore: cast_nullable_to_non_nullable
              as List<BotPerformance>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$BotDetailPageStateImplCopyWith<$Res>
    implements $BotDetailPageStateCopyWith<$Res> {
  factory _$$BotDetailPageStateImplCopyWith(_$BotDetailPageStateImpl value,
          $Res Function(_$BotDetailPageStateImpl) then) =
      __$$BotDetailPageStateImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({List<BotPerformance> activities});
}

/// @nodoc
class __$$BotDetailPageStateImplCopyWithImpl<$Res>
    extends _$BotDetailPageStateCopyWithImpl<$Res, _$BotDetailPageStateImpl>
    implements _$$BotDetailPageStateImplCopyWith<$Res> {
  __$$BotDetailPageStateImplCopyWithImpl(_$BotDetailPageStateImpl _value,
      $Res Function(_$BotDetailPageStateImpl) _then)
      : super(_value, _then);

  /// Create a copy of BotDetailPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? activities = null,
  }) {
    return _then(_$BotDetailPageStateImpl(
      activities: null == activities
          ? _value._activities
          : activities // ignore: cast_nullable_to_non_nullable
              as List<BotPerformance>,
    ));
  }
}

/// @nodoc

class _$BotDetailPageStateImpl implements _BotDetailPageState {
  const _$BotDetailPageStateImpl(
      {final List<BotPerformance> activities = const []})
      : _activities = activities;

  final List<BotPerformance> _activities;
  @override
  @JsonKey()
  List<BotPerformance> get activities {
    if (_activities is EqualUnmodifiableListView) return _activities;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_activities);
  }

  @override
  String toString() {
    return 'BotDetailPageState(activities: $activities)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$BotDetailPageStateImpl &&
            const DeepCollectionEquality()
                .equals(other._activities, _activities));
  }

  @override
  int get hashCode => Object.hash(
      runtimeType, const DeepCollectionEquality().hash(_activities));

  /// Create a copy of BotDetailPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$BotDetailPageStateImplCopyWith<_$BotDetailPageStateImpl> get copyWith =>
      __$$BotDetailPageStateImplCopyWithImpl<_$BotDetailPageStateImpl>(
          this, _$identity);
}

abstract class _BotDetailPageState implements BotDetailPageState {
  const factory _BotDetailPageState({final List<BotPerformance> activities}) =
      _$BotDetailPageStateImpl;

  @override
  List<BotPerformance> get activities;

  /// Create a copy of BotDetailPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$BotDetailPageStateImplCopyWith<_$BotDetailPageStateImpl> get copyWith =>
      throw _privateConstructorUsedError;
}

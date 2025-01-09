// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'feature_info_list_page.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$FeatureInfoListPageState {
  List<FeaturePipelineInfo> get infos => throw _privateConstructorUsedError;

  /// Create a copy of FeatureInfoListPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $FeatureInfoListPageStateCopyWith<FeatureInfoListPageState> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $FeatureInfoListPageStateCopyWith<$Res> {
  factory $FeatureInfoListPageStateCopyWith(FeatureInfoListPageState value,
          $Res Function(FeatureInfoListPageState) then) =
      _$FeatureInfoListPageStateCopyWithImpl<$Res, FeatureInfoListPageState>;
  @useResult
  $Res call({List<FeaturePipelineInfo> infos});
}

/// @nodoc
class _$FeatureInfoListPageStateCopyWithImpl<$Res,
        $Val extends FeatureInfoListPageState>
    implements $FeatureInfoListPageStateCopyWith<$Res> {
  _$FeatureInfoListPageStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of FeatureInfoListPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? infos = null,
  }) {
    return _then(_value.copyWith(
      infos: null == infos
          ? _value.infos
          : infos // ignore: cast_nullable_to_non_nullable
              as List<FeaturePipelineInfo>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$FeatureInfoListPageStateImplCopyWith<$Res>
    implements $FeatureInfoListPageStateCopyWith<$Res> {
  factory _$$FeatureInfoListPageStateImplCopyWith(
          _$FeatureInfoListPageStateImpl value,
          $Res Function(_$FeatureInfoListPageStateImpl) then) =
      __$$FeatureInfoListPageStateImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({List<FeaturePipelineInfo> infos});
}

/// @nodoc
class __$$FeatureInfoListPageStateImplCopyWithImpl<$Res>
    extends _$FeatureInfoListPageStateCopyWithImpl<$Res,
        _$FeatureInfoListPageStateImpl>
    implements _$$FeatureInfoListPageStateImplCopyWith<$Res> {
  __$$FeatureInfoListPageStateImplCopyWithImpl(
      _$FeatureInfoListPageStateImpl _value,
      $Res Function(_$FeatureInfoListPageStateImpl) _then)
      : super(_value, _then);

  /// Create a copy of FeatureInfoListPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? infos = null,
  }) {
    return _then(_$FeatureInfoListPageStateImpl(
      infos: null == infos
          ? _value._infos
          : infos // ignore: cast_nullable_to_non_nullable
              as List<FeaturePipelineInfo>,
    ));
  }
}

/// @nodoc

class _$FeatureInfoListPageStateImpl implements _FeatureInfoListPageState {
  const _$FeatureInfoListPageStateImpl(
      {final List<FeaturePipelineInfo> infos = const []})
      : _infos = infos;

  final List<FeaturePipelineInfo> _infos;
  @override
  @JsonKey()
  List<FeaturePipelineInfo> get infos {
    if (_infos is EqualUnmodifiableListView) return _infos;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_infos);
  }

  @override
  String toString() {
    return 'FeatureInfoListPageState(infos: $infos)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$FeatureInfoListPageStateImpl &&
            const DeepCollectionEquality().equals(other._infos, _infos));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(_infos));

  /// Create a copy of FeatureInfoListPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$FeatureInfoListPageStateImplCopyWith<_$FeatureInfoListPageStateImpl>
      get copyWith => __$$FeatureInfoListPageStateImplCopyWithImpl<
          _$FeatureInfoListPageStateImpl>(this, _$identity);
}

abstract class _FeatureInfoListPageState implements FeatureInfoListPageState {
  const factory _FeatureInfoListPageState(
      {final List<FeaturePipelineInfo> infos}) = _$FeatureInfoListPageStateImpl;

  @override
  List<FeaturePipelineInfo> get infos;

  /// Create a copy of FeatureInfoListPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$FeatureInfoListPageStateImplCopyWith<_$FeatureInfoListPageStateImpl>
      get copyWith => throw _privateConstructorUsedError;
}

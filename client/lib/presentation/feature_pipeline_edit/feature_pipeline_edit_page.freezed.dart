// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'feature_pipeline_edit_page.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#adding-getters-and-methods-to-our-models');

/// @nodoc
mixin _$FeaturePipelineEditPageState {
  List<FeaturePipelineOrder> get pipelines =>
      throw _privateConstructorUsedError;

  /// Create a copy of FeaturePipelineEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  $FeaturePipelineEditPageStateCopyWith<FeaturePipelineEditPageState>
      get copyWith => throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $FeaturePipelineEditPageStateCopyWith<$Res> {
  factory $FeaturePipelineEditPageStateCopyWith(
          FeaturePipelineEditPageState value,
          $Res Function(FeaturePipelineEditPageState) then) =
      _$FeaturePipelineEditPageStateCopyWithImpl<$Res,
          FeaturePipelineEditPageState>;
  @useResult
  $Res call({List<FeaturePipelineOrder> pipelines});
}

/// @nodoc
class _$FeaturePipelineEditPageStateCopyWithImpl<$Res,
        $Val extends FeaturePipelineEditPageState>
    implements $FeaturePipelineEditPageStateCopyWith<$Res> {
  _$FeaturePipelineEditPageStateCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  /// Create a copy of FeaturePipelineEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? pipelines = null,
  }) {
    return _then(_value.copyWith(
      pipelines: null == pipelines
          ? _value.pipelines
          : pipelines // ignore: cast_nullable_to_non_nullable
              as List<FeaturePipelineOrder>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$FeaturePipelineEditPageStateImplCopyWith<$Res>
    implements $FeaturePipelineEditPageStateCopyWith<$Res> {
  factory _$$FeaturePipelineEditPageStateImplCopyWith(
          _$FeaturePipelineEditPageStateImpl value,
          $Res Function(_$FeaturePipelineEditPageStateImpl) then) =
      __$$FeaturePipelineEditPageStateImplCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({List<FeaturePipelineOrder> pipelines});
}

/// @nodoc
class __$$FeaturePipelineEditPageStateImplCopyWithImpl<$Res>
    extends _$FeaturePipelineEditPageStateCopyWithImpl<$Res,
        _$FeaturePipelineEditPageStateImpl>
    implements _$$FeaturePipelineEditPageStateImplCopyWith<$Res> {
  __$$FeaturePipelineEditPageStateImplCopyWithImpl(
      _$FeaturePipelineEditPageStateImpl _value,
      $Res Function(_$FeaturePipelineEditPageStateImpl) _then)
      : super(_value, _then);

  /// Create a copy of FeaturePipelineEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? pipelines = null,
  }) {
    return _then(_$FeaturePipelineEditPageStateImpl(
      pipelines: null == pipelines
          ? _value._pipelines
          : pipelines // ignore: cast_nullable_to_non_nullable
              as List<FeaturePipelineOrder>,
    ));
  }
}

/// @nodoc

class _$FeaturePipelineEditPageStateImpl
    implements _FeaturePipelineEditPageState {
  const _$FeaturePipelineEditPageStateImpl(
      {final List<FeaturePipelineOrder> pipelines = const []})
      : _pipelines = pipelines;

  final List<FeaturePipelineOrder> _pipelines;
  @override
  @JsonKey()
  List<FeaturePipelineOrder> get pipelines {
    if (_pipelines is EqualUnmodifiableListView) return _pipelines;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_pipelines);
  }

  @override
  String toString() {
    return 'FeaturePipelineEditPageState(pipelines: $pipelines)';
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$FeaturePipelineEditPageStateImpl &&
            const DeepCollectionEquality()
                .equals(other._pipelines, _pipelines));
  }

  @override
  int get hashCode =>
      Object.hash(runtimeType, const DeepCollectionEquality().hash(_pipelines));

  /// Create a copy of FeaturePipelineEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  @pragma('vm:prefer-inline')
  _$$FeaturePipelineEditPageStateImplCopyWith<
          _$FeaturePipelineEditPageStateImpl>
      get copyWith => __$$FeaturePipelineEditPageStateImplCopyWithImpl<
          _$FeaturePipelineEditPageStateImpl>(this, _$identity);
}

abstract class _FeaturePipelineEditPageState
    implements FeaturePipelineEditPageState {
  const factory _FeaturePipelineEditPageState(
          {final List<FeaturePipelineOrder> pipelines}) =
      _$FeaturePipelineEditPageStateImpl;

  @override
  List<FeaturePipelineOrder> get pipelines;

  /// Create a copy of FeaturePipelineEditPageState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  _$$FeaturePipelineEditPageStateImplCopyWith<
          _$FeaturePipelineEditPageStateImpl>
      get copyWith => throw _privateConstructorUsedError;
}

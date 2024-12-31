// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'bot_detail_page.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$botDetailPageNotifierHash() =>
    r'0a8967ab2fa4fc7aada2945dbcbae61dac6c9ad2';

/// Copied from Dart SDK
class _SystemHash {
  _SystemHash._();

  static int combine(int hash, int value) {
    // ignore: parameter_assignments
    hash = 0x1fffffff & (hash + value);
    // ignore: parameter_assignments
    hash = 0x1fffffff & (hash + ((0x0007ffff & hash) << 10));
    return hash ^ (hash >> 6);
  }

  static int finish(int hash) {
    // ignore: parameter_assignments
    hash = 0x1fffffff & (hash + ((0x03ffffff & hash) << 3));
    // ignore: parameter_assignments
    hash = hash ^ (hash >> 11);
    return 0x1fffffff & (hash + ((0x00003fff & hash) << 15));
  }
}

abstract class _$BotDetailPageNotifier
    extends BuildlessAutoDisposeNotifier<BotDetailPageState> {
  late final Stream<BotPerformance> activities;

  BotDetailPageState build(
    Stream<BotPerformance> activities,
  );
}

/// See also [BotDetailPageNotifier].
@ProviderFor(BotDetailPageNotifier)
const botDetailPageNotifierProvider = BotDetailPageNotifierFamily();

/// See also [BotDetailPageNotifier].
class BotDetailPageNotifierFamily extends Family<BotDetailPageState> {
  /// See also [BotDetailPageNotifier].
  const BotDetailPageNotifierFamily();

  /// See also [BotDetailPageNotifier].
  BotDetailPageNotifierProvider call(
    Stream<BotPerformance> activities,
  ) {
    return BotDetailPageNotifierProvider(
      activities,
    );
  }

  @override
  BotDetailPageNotifierProvider getProviderOverride(
    covariant BotDetailPageNotifierProvider provider,
  ) {
    return call(
      provider.activities,
    );
  }

  static const Iterable<ProviderOrFamily>? _dependencies = null;

  @override
  Iterable<ProviderOrFamily>? get dependencies => _dependencies;

  static const Iterable<ProviderOrFamily>? _allTransitiveDependencies = null;

  @override
  Iterable<ProviderOrFamily>? get allTransitiveDependencies =>
      _allTransitiveDependencies;

  @override
  String? get name => r'botDetailPageNotifierProvider';
}

/// See also [BotDetailPageNotifier].
class BotDetailPageNotifierProvider extends AutoDisposeNotifierProviderImpl<
    BotDetailPageNotifier, BotDetailPageState> {
  /// See also [BotDetailPageNotifier].
  BotDetailPageNotifierProvider(
    Stream<BotPerformance> activities,
  ) : this._internal(
          () => BotDetailPageNotifier()..activities = activities,
          from: botDetailPageNotifierProvider,
          name: r'botDetailPageNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$botDetailPageNotifierHash,
          dependencies: BotDetailPageNotifierFamily._dependencies,
          allTransitiveDependencies:
              BotDetailPageNotifierFamily._allTransitiveDependencies,
          activities: activities,
        );

  BotDetailPageNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.activities,
  }) : super.internal();

  final Stream<BotPerformance> activities;

  @override
  BotDetailPageState runNotifierBuild(
    covariant BotDetailPageNotifier notifier,
  ) {
    return notifier.build(
      activities,
    );
  }

  @override
  Override overrideWith(BotDetailPageNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: BotDetailPageNotifierProvider._internal(
        () => create()..activities = activities,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        activities: activities,
      ),
    );
  }

  @override
  AutoDisposeNotifierProviderElement<BotDetailPageNotifier, BotDetailPageState>
      createElement() {
    return _BotDetailPageNotifierProviderElement(this);
  }

  @override
  bool operator ==(Object other) {
    return other is BotDetailPageNotifierProvider &&
        other.activities == activities;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, activities.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin BotDetailPageNotifierRef
    on AutoDisposeNotifierProviderRef<BotDetailPageState> {
  /// The parameter `activities` of this provider.
  Stream<BotPerformance> get activities;
}

class _BotDetailPageNotifierProviderElement
    extends AutoDisposeNotifierProviderElement<BotDetailPageNotifier,
        BotDetailPageState> with BotDetailPageNotifierRef {
  _BotDetailPageNotifierProviderElement(super.provider);

  @override
  Stream<BotPerformance> get activities =>
      (origin as BotDetailPageNotifierProvider).activities;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package

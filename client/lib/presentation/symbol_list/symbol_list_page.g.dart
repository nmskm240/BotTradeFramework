// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'symbol_list_page.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

String _$symbolListPageNotifierHash() =>
    r'9a87124c2eb9a9116be72146bd3e6ffca1cfdaea';

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

abstract class _$SymbolListPageNotifier
    extends BuildlessAutoDisposeNotifier<SymbolListPageState> {
  late final Iterable<Symbol> symbols;

  SymbolListPageState build(
    Iterable<Symbol> symbols,
  );
}

/// See also [SymbolListPageNotifier].
@ProviderFor(SymbolListPageNotifier)
const symbolListPageNotifierProvider = SymbolListPageNotifierFamily();

/// See also [SymbolListPageNotifier].
class SymbolListPageNotifierFamily extends Family<SymbolListPageState> {
  /// See also [SymbolListPageNotifier].
  const SymbolListPageNotifierFamily();

  /// See also [SymbolListPageNotifier].
  SymbolListPageNotifierProvider call(
    Iterable<Symbol> symbols,
  ) {
    return SymbolListPageNotifierProvider(
      symbols,
    );
  }

  @override
  SymbolListPageNotifierProvider getProviderOverride(
    covariant SymbolListPageNotifierProvider provider,
  ) {
    return call(
      provider.symbols,
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
  String? get name => r'symbolListPageNotifierProvider';
}

/// See also [SymbolListPageNotifier].
class SymbolListPageNotifierProvider extends AutoDisposeNotifierProviderImpl<
    SymbolListPageNotifier, SymbolListPageState> {
  /// See also [SymbolListPageNotifier].
  SymbolListPageNotifierProvider(
    Iterable<Symbol> symbols,
  ) : this._internal(
          () => SymbolListPageNotifier()..symbols = symbols,
          from: symbolListPageNotifierProvider,
          name: r'symbolListPageNotifierProvider',
          debugGetCreateSourceHash:
              const bool.fromEnvironment('dart.vm.product')
                  ? null
                  : _$symbolListPageNotifierHash,
          dependencies: SymbolListPageNotifierFamily._dependencies,
          allTransitiveDependencies:
              SymbolListPageNotifierFamily._allTransitiveDependencies,
          symbols: symbols,
        );

  SymbolListPageNotifierProvider._internal(
    super._createNotifier, {
    required super.name,
    required super.dependencies,
    required super.allTransitiveDependencies,
    required super.debugGetCreateSourceHash,
    required super.from,
    required this.symbols,
  }) : super.internal();

  final Iterable<Symbol> symbols;

  @override
  SymbolListPageState runNotifierBuild(
    covariant SymbolListPageNotifier notifier,
  ) {
    return notifier.build(
      symbols,
    );
  }

  @override
  Override overrideWith(SymbolListPageNotifier Function() create) {
    return ProviderOverride(
      origin: this,
      override: SymbolListPageNotifierProvider._internal(
        () => create()..symbols = symbols,
        from: from,
        name: null,
        dependencies: null,
        allTransitiveDependencies: null,
        debugGetCreateSourceHash: null,
        symbols: symbols,
      ),
    );
  }

  @override
  AutoDisposeNotifierProviderElement<SymbolListPageNotifier,
      SymbolListPageState> createElement() {
    return _SymbolListPageNotifierProviderElement(this);
  }

  @override
  bool operator ==(Object other) {
    return other is SymbolListPageNotifierProvider && other.symbols == symbols;
  }

  @override
  int get hashCode {
    var hash = _SystemHash.combine(0, runtimeType.hashCode);
    hash = _SystemHash.combine(hash, symbols.hashCode);

    return _SystemHash.finish(hash);
  }
}

@Deprecated('Will be removed in 3.0. Use Ref instead')
// ignore: unused_element
mixin SymbolListPageNotifierRef
    on AutoDisposeNotifierProviderRef<SymbolListPageState> {
  /// The parameter `symbols` of this provider.
  Iterable<Symbol> get symbols;
}

class _SymbolListPageNotifierProviderElement
    extends AutoDisposeNotifierProviderElement<SymbolListPageNotifier,
        SymbolListPageState> with SymbolListPageNotifierRef {
  _SymbolListPageNotifierProviderElement(super.provider);

  @override
  Iterable<Symbol> get symbols =>
      (origin as SymbolListPageNotifierProvider).symbols;
}
// ignore_for_file: type=lint
// ignore_for_file: subtype_of_sealed_class, invalid_use_of_internal_member, invalid_use_of_visible_for_testing_member, deprecated_member_use_from_same_package

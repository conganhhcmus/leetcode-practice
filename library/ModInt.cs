// ── Type Aliases ───────────────────────────────────────────────────
// Add to your global usings or top of file:
// using Z = ModInt<Mod1e9p7>;

namespace Library;

public interface IMod
{
    uint Value { get; }
    bool IsPrime { get; }
}

public readonly struct Mod1e9p7 : IMod
{
    public uint Value => 1_000_000_007u;
    public bool IsPrime => true;
}

public readonly struct Mod998 : IMod
{
    public uint Value => 998_244_353u;
    public bool IsPrime => true;
}

public readonly struct Mod1e9p9 : IMod
{
    public uint Value => 1_000_000_009u;
    public bool IsPrime => true;
}

public readonly struct DynMod : IMod
{
    private static uint _value = 1_000_000_007u;
    private static bool _isPrime = true;

    public static void Set(uint mod, bool isPrime = false)
    {
        if (mod < 2)
            throw new ArgumentException("Mod must be >= 2");
        _value = mod;
        _isPrime = isPrime;
    }

    public uint Value => _value;
    public bool IsPrime => _isPrime;
}

public readonly struct ModInt<T> : IEquatable<ModInt<T>>
    where T : struct, IMod
{
    private static readonly uint MOD = default(T).Value;
    private static readonly bool IS_PRIME = default(T).IsPrime;

    private readonly uint _v;

    // ── Constructors ───────────────────────────────────────────────
    public ModInt(long v)
    {
        var m = (long)MOD;
        _v = (uint)(v % m + m) % MOD;
    }

    public ModInt(ulong v) => _v = (uint)(v % MOD);

    private ModInt(uint v) => _v = v;

    // ── Properties ─────────────────────────────────────────────────
    public int Value => (int)_v;
    public uint RawValue => _v;
    public static uint Mod => MOD;

    // ── Arithmetic ─────────────────────────────────────────────────
    public static ModInt<T> operator +(ModInt<T> a, ModInt<T> b)
    {
        var v = a._v + b._v;
        return new ModInt<T>(v >= MOD ? v - MOD : v);
    }

    public static ModInt<T> operator -(ModInt<T> a, ModInt<T> b)
    {
        var v = a._v - b._v;
        return new ModInt<T>(v >= MOD ? v + MOD : v);
    }

    public static ModInt<T> operator *(ModInt<T> a, ModInt<T> b) =>
        new ModInt<T>((uint)((ulong)a._v * b._v % MOD));

    public static ModInt<T> operator /(ModInt<T> a, ModInt<T> b)
    {
        if (b._v == 0)
            throw new DivideByZeroException($"ModInt<{typeof(T).Name}> division by zero");
        return a * b.Inv();
    }

    public static ModInt<T> operator -(ModInt<T> v) => new ModInt<T>(v._v == 0 ? 0u : MOD - v._v);

    // ── Increment / Decrement ──────────────────────────────────────
    public static ModInt<T> operator ++(ModInt<T> v)
    {
        var x = v._v + 1;
        return new ModInt<T>(x == MOD ? 0u : x);
    }

    public static ModInt<T> operator --(ModInt<T> v) =>
        new ModInt<T>(v._v == 0 ? MOD - 1u : v._v - 1u);

    // ── Bitwise ────────────────────────────────────────────────────
    public static ModInt<T> operator &(ModInt<T> a, ModInt<T> b) => new ModInt<T>(a._v & b._v);

    public static ModInt<T> operator |(ModInt<T> a, ModInt<T> b) => new ModInt<T>(a._v | b._v);

    public static ModInt<T> operator ^(ModInt<T> a, ModInt<T> b) => new ModInt<T>(a._v ^ b._v);

    public static ModInt<T> operator >>(ModInt<T> a, int shift) => new ModInt<T>(a._v >> shift); // no re-reduce needed: shift only shrinks

    public static ModInt<T> operator <<(ModInt<T> a, int shift) =>
        new ModInt<T>((ulong)a._v << shift); // re-reduce via ulong constructor

    // ── Comparison ─────────────────────────────────────────────────
    public static bool operator ==(ModInt<T> a, ModInt<T> b) => a._v == b._v;

    public static bool operator !=(ModInt<T> a, ModInt<T> b) => a._v != b._v;

    public static bool operator >(ModInt<T> a, ModInt<T> b) => a._v > b._v;

    public static bool operator <(ModInt<T> a, ModInt<T> b) => a._v < b._v;

    public static bool operator >=(ModInt<T> a, ModInt<T> b) => a._v >= b._v;

    public static bool operator <=(ModInt<T> a, ModInt<T> b) => a._v <= b._v;

    public bool Equals(ModInt<T> other) => _v == other._v;

    public override bool Equals(object obj) => obj is ModInt<T> m && Equals(m);

    public override int GetHashCode() => _v.GetHashCode();

    // ── Implicit Conversions ───────────────────────────────────────
    public static implicit operator ModInt<T>(int v) => new ModInt<T>((long)v);

    public static implicit operator ModInt<T>(long v) => new ModInt<T>(v);

    public static implicit operator ModInt<T>(uint v) => new ModInt<T>((ulong)v);

    // ── Power ──────────────────────────────────────────────────────
    public ModInt<T> Pow(long n)
    {
        if (n < 0)
            return Inv().Pow(-n);
        var x = this;
        ModInt<T> r = 1;
        for (; n > 0; n >>= 1)
        {
            if ((n & 1) != 0)
                r *= x;
            x *= x;
        }
        return r;
    }

    // ── Inverse ────────────────────────────────────────────────────
    public ModInt<T> Inv()
    {
        if (_v == 0)
            throw new DivideByZeroException($"ModInt<{typeof(T).Name}> inverse of zero");
        if (IS_PRIME)
            return Pow((long)(MOD - 2u));

        long a = _v,
            b = MOD,
            x = 1,
            y = 0;
        while (b > 0)
        {
            long q = a / b;
            (a, b) = (b, a - q * b);
            (x, y) = (y, x - q * y);
        }
        if (a != 1)
            throw new InvalidOperationException($"{_v} has no inverse mod {MOD}");
        return new ModInt<T>(x);
    }

    public override string ToString() => _v.ToString();
}

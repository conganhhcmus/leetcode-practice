
# Bitwise Tricks for Competitive Programming (C#)

---

## 1. Check if a Number is Even or Odd
Use the least significant bit (LSB) to determine if a number is even or odd.

```csharp
int num = 5;
if ((num & 1) == 1)
    Console.WriteLine("Odd");
else
    Console.WriteLine("Even");
```

**Note:**
- If the LSB is 1, the number is odd.
- If the LSB is 0, the number is even.
- This method is faster than using the modulus operator (%).

---

## 2. Check if a Number is a Power of 2
A number is a power of 2 if it has exactly one bit set.

```csharp
bool IsPowerOf2(int n) {
    return (n > 0) && ((n & (n - 1)) == 0);
}
```

**Note:**
- This method removes the rightmost set bit using the expression `n & (n - 1)`.
- This check runs in **O(1)** time and is very efficient.

---

## 3. Toggle K-th Bit
Toggle (flip) the K-th bit of a number.

```csharp
int ToggleKthBit(int n, int k) {
    return n ^ (1 << k);
}
```

**Note:**
- XOR with `1 << k` flips the K-th bit.
- If the K-th bit was 1, it becomes 0, and vice versa.

---

## 4. Multiply or Divide by Powers of 2
Use bit shifting for fast multiplication and division.

```csharp
int MultiplyBy2(int n, int k) {
    return n << k;
}

int DivideBy2(int n, int k) {
    return n >> k;
}
```

**Note:**
- `n << k` shifts left, multiplying by 2^k.
- `n >> k` shifts right, dividing by 2^k.
- This method is **faster** than traditional multiplication and division.

---

## 5. Compute x % 2^k Efficiently
Use bitwise AND to compute the remainder.

```csharp
int ModPowerOf2(int x, int k) {
    return x & ((1 << k) - 1);
}
```

**Note:**
- `x & (2^k - 1)` is equivalent to `x % 2^k`.
- This approach is much faster than using the modulus operator `%`.

---

## 6. Count the Number of Set Bits
Using .NET's built-in BitOperations:

```csharp
using System.Numerics;

int CountSetBits(int n) {
    return BitOperations.PopCount((uint)n);
}
```

**Note:**
- The `BitOperations.PopCount` method counts the number of 1s in the binary representation of `n`.
- This is a highly optimized built-in method and is **faster** than manually iterating over the bits.

---

## 7. Even Odd and Set Bits Relationship

- Let x = number of set bits in A  
- Let y = number of set bits in B  
- Let z = number of set bits in (A ^ B)  
- If z is even, then A + B is even  
- If z is odd, then A + B is odd

**Note:**
- This trick is useful for checking if the sum of two numbers is even or odd based on their bit representations.

---

## 8. Changing the Number if a Condition Satisfies

```csharp
int x = 10;
x = 10 ^ 7 ^ x; // Swaps between 10 and 7
```

**Note:**
- XOR-ing two same numbers results in 0. This allows us to swap values efficiently.
- This trick can be extended to swap any two values without using a temporary variable.

---

## 9. Important Identity

```csharp
int A = 5, B = 3;
int sum1 = (A ^ B) + 2 * (A & B);
int sum2 = (A | B) + (A & B);
```

**Note:**
- These are useful identities in bitwise arithmetic for manipulating and combining bitwise operations.

---

## 10. Manipulating the k-th Bit

```csharp
bool IsKthBitSet(int X, int k) => (X & (1 << k)) != 0;

int ToggleKthBit(int X, int k) => X ^ (1 << k);

int SetKthBit(int X, int k) => X | (1 << k);

int UnsetKthBit(int X, int k) => X & ~(1 << k);
```

**Note:**
- These methods are essential for directly manipulating specific bits in a number.
- Checking, toggling, setting, and unsetting bits are crucial operations in many low-level algorithms.

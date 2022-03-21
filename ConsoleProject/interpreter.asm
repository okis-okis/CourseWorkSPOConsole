BITS 32

section .data
ns: db "", 10, 0
negative: db "-%d", 0
positiv: db "%d", 0
DAT0: db "c= ", 0
DAT1: db "t= ", 0
DAT2: db "d= ", 0
DAT3: db "g= ", 0
DAT4: db "w= ", 0
DAT5: db "Result: ", 0
c: dq 0
t: dq 0
d: dq 0
g: dq 0
w: dq 0

section .text
global main
extern printf
extern scanf
main:

xor eax, eax
xor ebx, ebx
xor ecx, ecx
xor edx, edx

mov eax, 1
mov [c], eax

push dword DAT0
call printf
add esp, 4

mov eax, [c]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos0

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con0

pos0:
push eax
push dword positiv
call printf
add esp, 8

con0:
push dword ns
call printf
add esp, 4

mov eax, 12
push eax
mov ebx, 14
pop eax
add eax, ebx

push eax
mov ebx, 41
pop eax
sub eax, ebx

push eax
mov ebx, 2
pop eax
mul ebx

mov [t], eax

push dword DAT1
call printf
add esp, 4

mov eax, [t]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos1

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con1

pos1:
push eax
push dword positiv
call printf
add esp, 8

con1:
push dword ns
call printf
add esp, 4

mov eax, 4
push eax
mov ebx, 2
pop eax
mov edx, 0
mov ecx, ebx
div ecx

mov [d], eax

mov eax, 0
push eax
mov ebx, 1
pop eax
sub eax, ebx

mov [g], eax

mov eax, 0
push eax
mov ebx, 1
pop eax
sub eax, ebx

push eax
mov ebx, 1
pop eax
sub eax, ebx

push eax
mov ebx, 1
pop eax
sub eax, ebx

push eax
mov ebx, 1
pop eax
sub eax, ebx

mov [w], eax

push dword DAT2
call printf
add esp, 4

mov eax, [d]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos2

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con2

pos2:
push eax
push dword positiv
call printf
add esp, 8

con2:
push dword ns
call printf
add esp, 4

push dword DAT3
call printf
add esp, 4

mov eax, [g]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos3

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con3

pos3:
push eax
push dword positiv
call printf
add esp, 8

con3:
push dword ns
call printf
add esp, 4

push dword DAT4
call printf
add esp, 4

mov eax, [w]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos4

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con4

pos4:
push eax
push dword positiv
call printf
add esp, 8

con4:
push dword ns
call printf
add esp, 4

mov eax, 7
push eax
mov eax, 3
push eax
mov eax, 10
push eax
mov eax, 12
push eax
mov eax, 3
push eax
mov ebx, 1
pop eax
add eax, ebx

mov ebx, eax
pop eax
mov edx, 0
mov ecx, ebx
div ecx

push eax
mov ebx, 1
pop eax
sub eax, ebx

mov ebx, eax
pop eax
mov edx, 0
mov ecx, ebx
div ecx

mov ebx, eax
pop eax
mul ebx

push eax
mov eax, 2
push eax
mov ebx, 3
pop eax
add eax, ebx

mov ebx, eax
pop eax
mov edx, 0
mov ecx, ebx
div ecx

mov ebx, eax
pop eax
add eax, ebx

push eax
mov ebx, 5
pop eax
sub eax, ebx

push eax
mov ebx, 3
pop eax
sub eax, ebx

push eax
mov ebx, 8
pop eax
add eax, ebx

mov [t], eax

push dword DAT5
call printf
add esp, 4

mov eax, [t]
mov ebx, 1000000000000000000000000000000b
cmp eax, ebx
jl pos5

xor eax, ebx
push eax
push dword negative
call printf
add esp, 8
jmp con5

pos5:
push eax
push dword positiv
call printf
add esp, 8

con5:
push dword ns
call printf
add esp, 4

ret 0

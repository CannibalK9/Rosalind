##http://rosalind.info/problems/wfmd/
import scipy.special as ss
import numpy as np

##N, m, g, k = map(int, open('C:\code\dataset.txt').read().split())
##
##ms = [1 if i==m else 0 for i in range(1+2*N)]
##
##for _ in range(g):
##    ms = [sum([ss.binom(2*N,r,0.5*i/N)*ms[i] for i in range(1+2*N)]) for r in range(1+2*N)]
##
##print(ms)
##
##print('%.3f' % sum(ms[:1+2*N-k]))

N = 4
N2 = N * 2

 # M[k,m] = P(Bin(2n,p) = k)    where p = m/2n
M = np.matrix(np.zeros((N2+1,N2+1)))
for m0 in range(N2+1):
    for m1 in range(N2+1):
        p = float(m0)/N2
        M[m0,m1] = ss.binom(N2,m1) * p**m1 * (1-p) ** (N2-m1)

print(M)




import scipy.special as ss
import numpy
from operator import mul
from fractions import Fraction

def WrightFisherModel( N, m, g, k ):
    pRec = 1.0 - (m/(2.0*N))
    p = [comb(2*N,i)*((pRec)**i)*(1.0-pRec)**(2*N-i) for i in xrange(1,2*N+1)]
    for gen in xrange(2,g+1):
        tempP = []
        for j in xrange(1,2*N+1):
            tempTerm = [comb(2*N, j)*((x/(2.0*N))**j)*(1.0-(x/(2.0*N)))**(2*N-j) for x in xrange(1,2*N+1)]
            tempP.append(sum([tempTerm[i]*p[i] for i in xrange(len(tempTerm))]))
        p = tempP
    return sum(p[k-1:])

def comb( n, k ):
    return int(reduce(mul,(Fraction(n-i,i+1) for i in xrange(k)),1))


data = list(map(int, open('C:\code\dataset.txt').read().split()))
alleles = int(data[0] * 2)
dominant = float(data[1])
generations = data[2]
least = int(data[3])

p = dominant / alleles
q = 1 - p

print WrightFisherModel(alleles/2,dominant,generations,least)

##print(p)
##print(q)
##hh = ss.binom(alleles, least)
##q = (hh * (q**k) * (p**(alleles - k)))
##p = 1 - q
print(p)
print(q)

total_p = 0
for k in range(1, 2):
    total_p += (ss.binom(alleles, k) * (q**k) * (p**(alleles - k)))
    print(total_p)

print

q = total_p
p = 1 - q
print(p)
print(q)

total_p = 0
for k in range(1, 2):
    total_p += (ss.binom(alleles, k) * (q**k) * (p**(alleles - k)))
    print(total_p)

print

q = total_p
p = 1 - q
print(p)
print(q)
